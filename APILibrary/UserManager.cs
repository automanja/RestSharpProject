using APILibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary
{
    public class UserManager
    {
        public UserSetDTO GetAllUsers(string endpoint)
        {
            var api = new APIHelper();
            var request = api.CreateGetRequest();
            var client = api.SetUri(endpoint);
            var response = api.GetResponse(client, request);
            var content = api.GetContent<UserSetDTO>(response);
            return content;
        }

        public CreateUserDTO CreateUser(string endpoint, dynamic payload)
        {
            var api = new APIHelper();
            var serializedRequest = api.Serialize(payload);
            var request = api.CreatePostRequest(serializedRequest);
            var client = api.SetUri(endpoint);
            var response = api.GetResponse(client, request);
            return api.GetContent<CreateUserDTO>(response);           
        }


    }
}
