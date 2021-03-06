﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataTransaction
{
    public class ManageLiquidationType
    {
        public static Liquidation_Types Deserialize<T>(string Data)
        {
            try
            {
                Liquidation_Types a = (Liquidation_Types)jsonHub.Deserialize<T>(Data);
                return a == null ? null : a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static List<Liquidation_Types> DeserializeList<T>(string data)
        {
            try
            {
                List<Liquidation_Types> L = (List<Liquidation_Types>)jsonHub.Deserialize<T>(data);
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
                if (o is List<Liquidation_Types>)
                {
                    return (String)jsonHub.Serialize((List<Liquidation_Types>)o);
                }
                else
                {
                    return (string)jsonHub.Serialize((Liquidation_Types)o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }
        public static List<Liquidation_Types> GetAll()
        {
            using (ef_manager_newEntities db = new ef_manager_newEntities())
            {
                return db.Liquidation_Types.ToList();
            }
        }

        public static bool Insert(Liquidation_Types lt)
        {
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Liquidation_Types.Add(lt);
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

        public static Liquidation_Types GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                Liquidation_Types s = null;
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    s = db.Liquidation_Types.Where(m => m.Liqudation_Type_ID == id).FirstOrDefault();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool IsExist(Liquidation_Types lt)
        {
            return GetById(lt.Liqudation_Type_ID) == null ? false : true;
        }

        public static bool Edit(Liquidation_Types lt)
        {
            if (lt == null)
            {
                throw new ArgumentNullException("Liquidation Type");
            }
            try
            {
                using (ef_manager_newEntities db = new ef_manager_newEntities())
                {
                    db.Entry(lt).State = EntityState.Modified;
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
                    db.Liquidation_Types.Remove(db.Liquidation_Types.Where(x => x.Liqudation_Type_ID == ID).FirstOrDefault());
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
