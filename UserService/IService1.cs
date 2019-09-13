using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        UserDetails LoginUser(string username, string password);

        [OperationContract]
        bool RegisterUser(string username, string email, string password, string rptPassword,
            string first_name, string last_name, string contact_number);
    }

}
