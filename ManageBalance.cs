using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransaction
{
    class ManageBalance
    {
        //ef_manager_newEntities db = new ef_manager_newEntities();
        //public bool addBalance(Balance bal)
        //{
        //    try
        //    {
        //        db.Balances.Add(bal);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return false;
        //    }
        //}
        public Balance GetByID(int? UserId)
        {
            if (UserId == null)
            {
                return null;
            }
            Balance Result = null;
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    decimal d = (db.Balances.Where(x => x.User_ID == UserId).FirstOrDefault().Balance1 - db.FrozenBalances.Where(x => x.User_ID == UserId && x.IsReleased == false).Sum(x => x.Balance)) + db.Transactions.Where(x => x.User_ID == UserId).Sum(x => x.Amount);
                    //Result = new Balance() { Balance1 = d ,  };
                    //baki
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return Result;
        }
        public Boolean UpdateBalance(int? UserId, List<Symbol> Syms)
        {
            if (UserId == null)
            {
                throw new Exception("UserID cannot be null");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    decimal Result = (db.Balances.Where(x => x.User_ID == UserId).FirstOrDefault().Balance1 - db.FrozenBalances.Where(x => x.User_ID == UserId && x.IsReleased == false).Sum(x => x.Balance)) + db.Transactions.Where(x => x.User_ID == UserId).Sum(x => x.Amount);
                    Balance B = db.Balances.Where(x => x.User_ID == UserId).FirstOrDefault();
                    B.Balance1 = Result;
                    db.Entry(B).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    db.OrderBooks.Where(x => x.IS_Order_Closed == true).ToList().ForEach(T => db.History_OrderBook.Add(ConvertOrderBook(T)));
                    db.Transactions
                    //db.OrderBooks.Where(x => x.IS_Order_Closed == false).ToList().ForEach(T => db.History_OrderBook.Add(ConvertOrderBook(T, true)));

                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        private History_OrderBook ConvertOrderBook(OrderBook o, bool IsCF = false)
        {
            if (o == null)
            {
                return null;
            }
            History_OrderBook h = new History_OrderBook();
            try
            {
                h.History_Order_ID = o.Order_ID;
                h.User_ID = o.User_ID;
                h.Order_Side = o.Order_Side;
                h.Order_Type_ID = o.Order_Type_ID;
                h.Symbol_ID = o.Symbol_ID;
                h.Quantity = o.Quantity;
                h.Price = o.Price;
                h.Order_Status_ID = o.Order_Status_ID;
                h.Original_Order_ID = o.Original_Order_ID;
                h.ISCF = false;
                h.InsertDate = o.Insert_Date;
                h.UpdateDate = DateTime.Now;
                h.Comments = o.Comments;
                h.CFRate = IsCF == false ? 0 : 0; //get rate here
                h.NewOrderID = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return h;
        }
        //public Boolean DeleteBalance(Balance bal)
        //{
        //    try
        //    {
        //        db.Balances.Remove(bal);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return false;
        //    }
        //}
    }
}
