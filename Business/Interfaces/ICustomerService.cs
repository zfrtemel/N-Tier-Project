using Business.Request;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces;
public interface ICustomerService
{
    public bool CreateCustomer(CreateUserRequest request);
    public bool UpdateCustomer(int id, UpdateUserRequest request);
    public bool DeleteCustomer(int id);
    public ICollection<UserEntity> GetCustomers();

}
