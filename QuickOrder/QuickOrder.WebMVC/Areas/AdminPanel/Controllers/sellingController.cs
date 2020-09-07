using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class sellingController : Controller
    {
        IUnitOfWork ctx;
        public sellingController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: AdminPanel/selling
        public ActionResult Index()
        {
            return View(ctx.saleProductBll.getAll().OrderByDescending(x=>x.orderDate).ToList());
        }
        [HttpPost]
        public ActionResult showDetail (int id)
        {
            var data = ctx.saleProductsDetailBll.getAll().Where(x => x.SaleProducts.id == id).ToList();
            List<sendDetail> send = new List<sendDetail>();
            foreach (var item in data)
            {
                sendDetail sendData = new sendDetail {
                    count=item.count,
                    productName=item.Products.name
                };
                send.Add(sendData);
            }
            return Json(send);
        }
        [HttpPost]
        public ActionResult billDetail(int id)
        {
            var bill = ctx.billBll.getOneIsThereSaleProduct( id);
            sendBillDetailDTO dto = new sendBillDetailDTO();

            dto.name = bill.name;
            dto.surname = bill.surname;
            dto.orderCode = (Guid)bill.orderCode;

             dto.orderDate = bill.orderDate;
            

            
            dto.payType = bill.payType;
            dto.date = bill.billDate;
            dto.phone = bill.phone.ToString();
            dto.totalPrice = bill.totalPrice;

            
            return Json(dto);
        }
        [HttpPost]
        public int orderShowed(int id)
        {
            SaleProducts rez = ctx.saleProductBll.getOne(id);
            if (ModelState.IsValid)
            {
                rez.status = false;
                bool result = ctx.saleProductBll.add(rez);
     


                if (result)
                {
                    return 1;
                }

                return 0;
            }
            return 0;

        }
    }
}
public class sendBillDetailDTO
{
    public string name { get; set; }
    public string surname { get; set; }
    public Guid orderCode { get; set; }
    public string phone { get; set; }
    public string payType { get; set; }
    public DateTime date { get; set; }
    public DateTime? orderDate { get; set; }
    public decimal totalPrice { get; set; }
}
public class sendDetail
{
    public string productName { get; set; }
    public int count { get; set; }

}