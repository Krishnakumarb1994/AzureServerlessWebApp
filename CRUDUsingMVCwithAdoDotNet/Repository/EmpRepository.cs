using System;
using System.Collections.Generic;
using CRUDUsingMVC.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
namespace CRUDUsingMVC.Repository
{
    public class EmpRepository
    {
        public bool AddEmployee(EmpModel obj)
        {
            string endPoint = string.Empty;
            HttpClient client = new HttpClient();
            endPoint = @"https://azurepocfunctionapp.azurewebsites.net/api/GetEmployeeCount?code=6FqWuOFZpKklYQi2vfzNVqtGB5dHpiAve3SXb597IesHCYmhxzlCxg==";
            HttpResponseMessage countresponse = client.GetAsync(endPoint).Result;
            int countresult = (countresponse != null && countresponse.StatusCode.ToString() == "OK" ? Convert.ToInt32(countresponse.Content.ReadAsStringAsync().Result) : 0);
            countresult++;
            endPoint = @"https://azurepocfunctionapp.azurewebsites.net/api/CreateEmployeeFunction?code=fax4e8ZNLJi1YAjCug/ngyKqE3YLjTdQNO8GELZ7NQ7hzH1xyd0ddQ==";
            string myJson = "{'Id': '"+ countresult + "','FirstName':'" + obj.FirstName + "','LastName':'" + obj.LastName+ "','Age':'"+ obj.Age +"','DateofBirth':'" + obj.DateofBirth + "' ,'Address':'"+ obj.Address + "','IsActive':'"+ obj.IsActive + "'}";
            HttpResponseMessage response = client.PostAsync(endPoint, new StringContent(myJson, Encoding.UTF8, "application/json")).Result;
            string result = (response != null && response.StatusCode.ToString() == "OK" ? response.Content.ReadAsStringAsync().Result : null);
            if (!string.IsNullOrWhiteSpace(result))
            { return true; }
            else
            { return false; }
        }

        public List<EmpModel> GetAllEmployees()
        {
            string result = string.Empty;
            HttpClient client = new HttpClient();
            string endPoint = @"https://azurepocfunctionapp.azurewebsites.net/api/GetEmployeeFunction?code=c4askXon01fGUH4YKf6kN18gKfaf/vuz89M2u32zn4mKu9ndoMRyJg==";
            HttpResponseMessage response = client.GetAsync(endPoint).Result;
            result = (response != null && response.StatusCode.ToString() == "OK" ? response.Content.ReadAsStringAsync().Result : null);
            List<EmpModel> EmpList =new List<EmpModel>();
            EmpList = JsonConvert.DeserializeObject<List<EmpModel>>(result);
            return EmpList;
        }

        public bool UpdateEmployee(EmpModel obj)
        {
            HttpClient client = new HttpClient();
            string endPoint = @"https://azurepocfunctionapp.azurewebsites.net/api/UpdateEmployeeFunction?code=OkjvVX0bWA7Xj2xYpmAmU7oMpsOrDQhEJ7FDSngHYgQNQawKnThecQ==";
            string myJson = "{'Id': '"+ obj.Empid +"','FirstName':'" + obj.FirstName + "','LastName':'" + obj.LastName + "','Age':'" + obj.Age + "','DateofBirth':'" + obj.DateofBirth + "' ,'Address':'" + obj.Address + "','IsActive':'" + obj.IsActive + "'}";
            HttpResponseMessage response = client.PostAsync(endPoint, new StringContent(myJson, Encoding.UTF8, "application/json")).Result;
            string result = (response != null && response.StatusCode.ToString() == "OK" ? response.Content.ReadAsStringAsync().Result : null);
            if (!string.IsNullOrWhiteSpace(result))
            { return true; }
            else
            { return false; }
        }
        public bool DeleteEmployee(int Id)
        {
            string result = string.Empty;
            HttpClient client = new HttpClient();
            string endPoint = @"https://azurepocfunctionapp.azurewebsites.net/api/DeleteEmployeeFunction?code=tRU1lX7lNPBolb/V4CllOAf9eyAqLVrAVq5sKWCizPX3Nex5ma2tOg==&ID=" + Id;
            HttpResponseMessage response = client.GetAsync(endPoint).Result;
            result = (response != null && response.StatusCode.ToString() == "OK" ? response.Content.ReadAsStringAsync().Result : null);
            if (!string.IsNullOrWhiteSpace(result))
            { return true; }
            else
            { return false; }
        }
    }
}