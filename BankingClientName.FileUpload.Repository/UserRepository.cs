﻿using BankingClientName.FileUpload.BusinessEntities.Interfaces;
using BankingClientName.FileUpload.BusinessEntities.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingClientName.FileUpload.Repository
{
    public   class UserRepository: IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> InvokeUsersList()//Invoke means calling
        {
            string Url = Convert.ToString(_config.GetSection("UserApis:GetUsersApiUrl").Value);
            //Don't write the 3rd part api url here.we must read from apssettings.json
            // string url = "https://fakerestapi.azurewebsites.net/api/v1/Users";
            HttpClient client = new HttpClient();//which is used to communicate with 3rdpart apis.
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Url);
            //what type of response you are expecting api response.you should specify here.
            request.Headers.Add("accept", "application/json");
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
        public async Task<string> InvokeUsersById(int id)
        {
            string Apiurl = Convert.ToString(_config.GetSection("UserApis:GetUsersByIdApiUrl").Value);

            string url = string.Format(Apiurl, id);

            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("accept", "application/json");//this line indicates i need json format data from that api.
            HttpResponseMessage response = await client.SendAsync(request);//sendasync() method will send the request to 3rd party url.
            // response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
        public async Task<string> InsertUserData(User userDetail)
        {
            string url = Convert.ToString(_config.GetSection("UserApis:InsertUserApiUrl").Value);
            //string url = "https://fakerestapi.azurewebsites.net/api/v1/Users";
            //SerializeObject means:Serialize the specified object into json string format.
            var serializedata = JsonConvert.SerializeObject(userDetail);//here we are converting the object data into json format.
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("accept", "application/json");
            StringContent content = new StringContent(serializedata, null, "application/json");
            request.Content = content;
            HttpResponseMessage response = await client.SendAsync(request);//this request object contain all the apiurl information and data.
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> UpdateUserData(User userDetail, int id)
        {
            string ApiUrl = Convert.ToString(_config.GetSection("UserApis:UpdateUserApiUrl").Value);
            string url = string.Format(ApiUrl, id);
            var serializedata = JsonConvert.SerializeObject(userDetail);
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("accept", "application/json");
            StringContent content = new StringContent(serializedata, null, "application/json");
            request.Content = content;
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
        public async Task<string> DeleteUserData(int id)
        {
            string ApiUrl = Convert.ToString(_config.GetSection("UserApis:DeleteUserApiUrl").Value);
            string url = string.Format(ApiUrl, id);
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("accept", "application/json");
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
    }
}
