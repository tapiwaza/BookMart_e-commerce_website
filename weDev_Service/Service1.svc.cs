using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TeamweDev_GP_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public User Login(string email, string password)
        {
            var sysuser = (from s in db.Users
                           where s.Email.Equals(email) &&
                           s.Password.Equals(password)
                           select s).FirstOrDefault();

            if (sysuser != null)
            {
                var tempUser = new User
                {
                    Id = sysuser.Id,
                    Email = sysuser.Email,
                    UserType = sysuser.UserType,
                };
                return tempUser;
            }
            else
            {
                return null;
            }
        }

        public int register(User user)
        {
            var sysUser = (from s in db.Users
                           where s.Email.Equals(user.Email) &&
                           s.Password.Equals(user.Password)
                           select s).FirstOrDefault();

            if (sysUser == null)
            {
                var newUser = new User
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Password = user.Password,
                    UserType = user.UserType, 
                    DateReg = System.DateTime.Now
                };

                db.Users.InsertOnSubmit(newUser);
                try
                {
                    db.SubmitChanges();
                    //success
                    return 1;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //error
                    return -1;
                }
            }
            else
            {
                //user exists
                return 0;
            }
        }

        public List<Product> getAllProducts()
        {
            var Prods = new List<Product>();

            var Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrStatus.Equals("active")
                        select p).DefaultIfEmpty();

            foreach (Product p in Prod)
            {
                Prods.Add(p);
            }

            return Prods;
        }

        public Product getProduct(int ID)
        {
            var Prod = (from p in db.Products
                        where p.Id.Equals(ID) &&
                        p.PrStatus.Equals("active")
                        select p).FirstOrDefault();

            if (Prod != null)
            {
                var tempProd = new Product
                {
                    Id = Prod.Id,
                    PrCategory = Prod.PrCategory,
                    PrDescription = Prod.PrDescription,
                    PrImage = Prod.PrImage,
                    PrName = Prod.PrName,
                    PrOldPrice = Prod.PrOldPrice,
                    PrPrice = Prod.PrPrice,
                    PrQuantity = Prod.PrQuantity,
                };
                return tempProd;
            }
            else
            {
                return null;
            }
        }

        public List<Product> getAllProductsAlphabetically()
        {
            var Prods = new List<Product>();

            var Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrStatus.Equals("active")
                        orderby p.PrName ascending
                        select p).DefaultIfEmpty();

            foreach (Product p in Prod)
            {
                var product = new Product
                {
                    Id = p.Id,
                    PrName = p.PrName,
                    PrCategory = p.PrCategory,
                    PrPrice = p.PrPrice,
                    PrOldPrice = p.PrOldPrice,
                    PrImage = p.PrImage
                };

                Prods.Add(product);
            }

            return Prods;
        }

        public List<Product> getAllProductsByPrice()
        {
            var Prods = new List<Product>();

            var Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrStatus.Equals("active")
                        orderby p.PrPrice ascending
                        select p).DefaultIfEmpty();

            foreach (Product p in Prod)
            {
                var product = new Product
                {
                    Id = p.Id,
                    PrName = p.PrName,
                    PrCategory = p.PrCategory,
                    PrPrice = p.PrPrice,
                    PrOldPrice = p.PrOldPrice,
                    PrImage = p.PrImage
                };

                Prods.Add(product);
            }

            return Prods;
        }

        public List<Product> getAllProductsPriceFiltered(int min, int max)
        {
            var Prods = new List<Product>();

            var Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrPrice >= min &&
                        p.PrPrice <= max &&
                        p.PrStatus.Equals("active")
                        orderby p.PrPrice ascending
                        select p).DefaultIfEmpty();

            foreach (Product p in Prod)
            {
                var product = new Product
                {
                    Id = p.Id,
                    PrName = p.PrName,
                    PrCategory = p.PrCategory,
                    PrPrice = p.PrPrice,
                    PrOldPrice = p.PrOldPrice,
                    PrImage = p.PrImage
                };

                Prods.Add(product);
            }

            return Prods;
        }

        public bool editProduct(Product product)
        {
            var prod = (from u in db.Products
                        where u.Id == product.Id
                        select u).FirstOrDefault();

            if (prod != null)
            {
                prod.PrCategory = product.PrCategory;
                prod.PrDescription = product.PrDescription;
                prod.PrImage = product.PrImage;
                prod.PrName = product.PrName;
                prod.PrOldPrice = product.PrOldPrice;
                prod.PrPrice = product.PrPrice;
                prod.PrQuantity = product.PrQuantity;
                prod.PrStatus = product.PrStatus;

                try
                {
                    db.SubmitChanges();
                    //success
                    return true;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //error
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Product> getAllProductsCategoryFiltered(char aORnORe)
        {
            var Prods = new List<Product>();

            var Prod = (from p in db.Products
                        where p.PrQuantity < 0 &&
                        p.PrStatus.Equals("active")
                        select p).DefaultIfEmpty();

            if (aORnORe.Equals('a') || aORnORe.Equals('A'))
            {
                Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrCategory.Equals("audio") &&
                        p.PrStatus.Equals("active")
                        orderby p.PrPrice ascending
                        select p).DefaultIfEmpty();
            }
            else if (aORnORe.Equals('e') || aORnORe.Equals('E'))
            {
                Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrCategory.Equals("ebook") &&
                        p.PrStatus.Equals("active")
                        orderby p.PrPrice ascending
                        select p).DefaultIfEmpty();
            }
            else if (aORnORe.Equals('n') || aORnORe.Equals('N'))
            {
                Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrCategory.Equals("novel") &&
                        p.PrStatus.Equals("active")
                        orderby p.PrPrice ascending
                        select p).DefaultIfEmpty();
            }



            foreach (Product p in Prod)
            {
                var product = new Product
                {
                    Id = p.Id,
                    PrName = p.PrName,
                    PrCategory = p.PrCategory,
                    PrPrice = p.PrPrice,
                    PrOldPrice = p.PrOldPrice,
                    PrImage = p.PrImage,
                    PrStatus = p.PrStatus,
                    PrQuantity = p.PrQuantity
                };

                Prods.Add(product);
            }

            return Prods;
        }

        public List<Product> getAllProductsQuantityFiltered(int min, int max)
        {
            var Prods = new List<Product>();

            var Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrQuantity >= min &&
                        p.PrQuantity <= max
                        
                        orderby p.PrQuantity ascending
                        select p).DefaultIfEmpty();

            foreach (Product p in Prod)
            {
                var product = new Product
                {
                    Id = p.Id,
                    PrName = p.PrName,
                    PrCategory = p.PrCategory,
                    PrQuantity = p.PrQuantity,
                    PrPrice = p.PrPrice,
                    PrOldPrice = p.PrOldPrice,
                    PrImage = p.PrImage,
                    PrStatus = p.PrStatus
                };

                Prods.Add(product);
            }

            return Prods;
        }

        public List<Product> getAllDiscountedProducts()
        {
            var Prods = new List<Product>();

            var Prod = (from p in db.Products
                        where p.PrQuantity > 0 &&
                        p.PrStatus.Equals("active") &&
                        p.PrOldPrice > 0
                        orderby p.PrPrice ascending
                        select p).DefaultIfEmpty();

            foreach (Product p in Prod)
            {
                var product = new Product
                {
                    Id = p.Id,
                    PrName = p.PrName,
                    PrCategory = p.PrCategory,
                    PrPrice = p.PrPrice,
                    PrOldPrice = p.PrOldPrice,
                    PrImage = p.PrImage
                };

                Prods.Add(p);
            }

            return Prods;
        }

        public int addProduct(Product product)
        {
            var prod = (from u in db.Products
                        where u.Id == product.Id
                        select u).FirstOrDefault();

            if (prod == null)
            {
                var newProd = new Product
                {
                    PrName = product.PrName,
                    PrDescription = product.PrDescription,
                    PrCategory = product.PrCategory,
                    PrQuantity = product.PrQuantity,
                    PrPrice = product.PrPrice,
                    PrOldPrice = product.PrOldPrice,
                    PrStatus = product.PrStatus,
                    PrImage = product.PrImage
                };


                db.Products.InsertOnSubmit(newProd);
                try
                {
                    db.SubmitChanges();
                    //success
                    return 1;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //error
                    return -1;
                }
            }
            else
            {
                //product exists
                return 0;
            }
        }

        public int removeProduct(int pID)
        {
            var prod = (from u in db.Products
                        where u.Id == pID
                        select u).FirstOrDefault();

            if (prod != null)
            {
                prod.PrStatus = "inactive";

                try
                {
                    db.SubmitChanges();
                    //success
                    return 1;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //error
                    return -1;
                }
            }

            else
            {
                //product does not exists
                return 0;
            }
        }

        public int addToCart(Cart cart)
        {
            var myCart = (from s in db.Carts
                          where s.User_Id == cart.User_Id && s.Prod_Id == cart.Prod_Id
                          select s).FirstOrDefault();

            if (myCart == null)
            {
                var addCart = new Cart
                {
                    Prod_Id = cart.Prod_Id,
                    User_Id = cart.User_Id,
                    Quantity = 1,
                };

                db.Carts.InsertOnSubmit(addCart);
                try
                {
                    db.SubmitChanges();
                    //success
                    return 1;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //error
                    return -1;
                }

            }
            else
            {
                myCart.Quantity += 1;
                try
                {
                    db.SubmitChanges();
                    //success
                    return 1;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //error
                    return -1;
                }
            }

        }

        public int removeFromCart(Cart cart)
        {
            var myCart = (from s in db.Carts
                          where s.User_Id == cart.User_Id && s.Prod_Id == cart.Prod_Id
                          select s).FirstOrDefault();
            int items = 0;

            if(myCart != null)
            {
                items++;
            if(myCart.Quantity > 1)
            {
                myCart.Quantity -= 1;
                try
                {
                    db.SubmitChanges();
                    //success
                    return items;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //error
                    return -1;
                }
            }
            else
            {
                db.Carts.DeleteOnSubmit(myCart);
                try
                {
                    db.SubmitChanges();
                    //success
                    return items;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    //error
                    return -1;
                }
            }
            }
            else
            {
                return items;
            }
                //var addCart = new Cart
                //{
                //    Prod_Id = cart.Prod_Id,
                //    User_Id = cart.User_Id,
                //    Quantity -= 1,
                //};
        }
        public int numItemsInCart(int u_Id){

            dynamic u = (from c in db.Carts
                         where c.User_Id == u_Id
                         select c);
            int quantity = 0;
            if(u != null)
            {

                foreach(Cart c in u)
                {
                    quantity += c.Quantity;
                }
                    return quantity;
            }
            else
            {
                return 0;
            }
           

        }

        public List<Cart> getProdsInCart(int u_id)
        {
            List<Cart> Prods = new List<Cart>();
            var prod = (from c in db.Carts
                        where (c.User_Id == u_id)
                        select c).DefaultIfEmpty();

            if(prod != null)
            {

            foreach(Cart c in prod)
            {
                    Prods.Add(c);
            }
                return Prods;
            }
            else
            {
                return null;
            }

        }

        public int purchase(Invoice inv)
        {
            
            var newInv = new Invoice
            {
                User_Id = inv.User_Id,
                Date = inv.Date,
                Quantity = inv.Quantity,
                Total_ = inv.Total_
            };

            db.Invoices.InsertOnSubmit(newInv);
            try
            {
                db.SubmitChanges();
                //success
                return 1;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                //error
                return -1;
            }
        }

        public List<Invoice> existingInvoices(int id)
        {
            List<Invoice> invs = new List<Invoice>();

            var userInv = (from s in db.Invoices
                           where s.User_Id.Equals(id)
                           select s).DefaultIfEmpty();

            if(userInv != null)
            {
                foreach(Invoice invoice in userInv)
                {
                    invs.Add(invoice);
                }

                return invs;
            }
            else
            {
                return null;
            }

        }

       

        public int getNumOfNovels()
        {
            var novs = (from i in db.Products
                        where i.PrCategory.Equals("novel") 
                        select i).Count();
            return novs;
        }

        public int getNumOfEbooks()
        {
            var novs = (from i in db.Products
                        where i.PrCategory.Equals("ebook")
                        select i).Count();
            return novs;
        }

        public int getNumOfAudioBooks()
        {
            var novs = (from i in db.Products
                        where i.PrCategory.Equals("audio")
                        select i).Count();
            return novs;
        }

        public int getAllRegisteredUsers()
        {
            var users = (from u in db.Users
                         select u).Count();
            return users;
        }

        public int getAllRegManagers()
        {
            var mans = (from i in db.Users
                       where i.UserType.Equals("Manager")
                       select i).Count();
            return mans;
        }

        public int getAllRegCustomers()
        {
            var custs = (from i in db.Users
                         where i.UserType.Equals("Customer")
                         select i).Count();
            return custs;
        }

        public int numOfRegisteredUsers(DateTime date)
        {
            var users = (from u in db.Users
                         where u.DateReg.Equals(date)
                         select u).Count();
            return users;
        }

        public int numOfCustomers(DateTime date)
        {
            var custs = (from i in db.Users
                         where i.DateReg.Equals(date)
                         where i.UserType.Equals("Customer")
                         select i).Count();
            return custs;
        }

        public int numOfRegManagers(DateTime date)
        {
            var mans = (from i in db.Users
                        where i.DateReg.Equals(date)
                        where i.UserType.Equals("Manager")
                         select i).Count();
            return mans;
        }

        public int numOfUsersWithTrans()
        {
            var users = (from u in db.Invoices
                         //orderby u.User_Id 
                        select  u ).Count();
            return users;
        }

        public int numOfUsersWith2Trans()
        {
            return 1;
        }

    }

}
