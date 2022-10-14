using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TeamweDev_GP_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        User Login(string email, string password);

        [OperationContract]
        int register(User user);

        [OperationContract]
        int addToCart(Cart cart);

        [OperationContract]
        int removeFromCart(Cart cart);

        [OperationContract]
        int numItemsInCart(int u_Id);

        [OperationContract]
        List<Cart> getProdsInCart(int u_id);


        [OperationContract]
        int addProduct(Product product);

        [OperationContract]
        int removeProduct(int pID);

        [OperationContract]
        Product getProduct(int ID);

        [OperationContract]
        List<Product> getAllProducts();

        [OperationContract]
        List<Product> getAllProductsAlphabetically();

        [OperationContract]
        List<Product> getAllProductsByPrice();

        [OperationContract]
        List<Product> getAllProductsPriceFiltered(int min, int max);
        [OperationContract]
        List<Product> getAllProductsQuantityFiltered(int min, int max);

        [OperationContract]
        List<Product> getAllProductsCategoryFiltered(char aORnORe);

        [OperationContract]
        List<Product> getAllDiscountedProducts();

        [OperationContract]
        bool editProduct(Product u);

        [OperationContract]
        int purchase(Invoice inv);

        [OperationContract]
        List<Invoice> existingInvoices(int id );

        [OperationContract]
        int getNumOfNovels();
        
        [OperationContract]
        int getNumOfAudioBooks();
        
        [OperationContract]
        int getNumOfEbooks();

        [OperationContract]
        int getAllRegisteredUsers();

        [OperationContract]
        int getAllRegManagers();

        [OperationContract]
        int getAllRegCustomers();

        [OperationContract]
        int numOfRegisteredUsers(DateTime date);

        [OperationContract]
        int numOfRegManagers(DateTime date);

        [OperationContract]
        int numOfCustomers(DateTime date);
        
        [OperationContract]
        int numOfUsersWithTrans();

        [OperationContract]
        int numOfUsersWith2Trans();



    }   
}
