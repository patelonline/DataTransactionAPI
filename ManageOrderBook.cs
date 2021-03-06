﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageOrderBook
    {
        public static OrderBook Deserialize<T>(string Data)
        {
            try
            {
                OrderBook a = (OrderBook)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<OrderBook> DeserializeList<T>(string data)
        {
            try
            {
                List<OrderBook> L = (List<OrderBook>)jsonHub.Deserialize<T>(data);
                return L == null ? null : L;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static string Serialize(Object o)
        {
            try
            {
                if (o == null) { return null; }
                if (o is List<OrderBook>)
                {
                    return (String)jsonHub.Serialize((List<OrderBook>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((OrderBook)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<OrderBook> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.OrderBooks.Include(x => x.Order_Status).Include(x => x.Order_Types).Include(x => x.OrderBook2).Include(x => x.Symbol).Include(x => x.User).ToList();
            }
        }

        public static bool Insert(OrderBook ob)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.OrderBooks.Add(ob);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static OrderBook GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                OrderBook s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.OrderBooks.Where(m => m.Order_ID == id).Include(x=>x.Order_Status).Include(x=>x.Order_Types).Include(x=>x.OrderBook2).Include(x=>x.Symbol).Include(x=>x.User).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static bool IsExist(OrderBook ob)
        {
            return GetById(ob.Order_ID) == null ? false : true;

        }

        public static bool Edit(OrderBook ob)
        {
            if (ob == null)
            {
                throw new ArgumentNullException("OrderBook");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(ob).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool Delete(int ID)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.OrderBooks.Remove(db.OrderBooks.Where(x => x.Order_ID == ID).FirstOrDefault());
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
