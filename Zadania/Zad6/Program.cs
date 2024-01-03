using System;
using System.Reflection;

namespace Zad6
{
    class Program
    {
        static void Main()
        {
            Customer customer = new Customer("Ignacy");
            Type customerType = typeof(Customer);

            SetDefaultPropertyValues(customer, customerType);
            DisplayCustomerProperties(customer, customerType);
        }

        static void SetDefaultPropertyValues(Customer customer, Type customerType)
        {
            foreach (PropertyInfo propertyInfo in customerType.GetProperties())
            {
                if (propertyInfo.CanWrite)
                {
                    SetPropertyValueBasedOnType(customer, propertyInfo);
                }
            }
        }

        static void SetPropertyValueBasedOnType(Customer customer, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(string))
            {
                propertyInfo.SetValue(customer, "baseValue");
            }
            else if (propertyInfo.PropertyType == typeof(int))
            {
                propertyInfo.SetValue(customer, 255);
            }
            else if (propertyInfo.PropertyType == typeof(bool))
            {
                propertyInfo.SetValue(customer, true);
            }
        }

        static void DisplayCustomerProperties(Customer customer, Type customerType)
        {
            foreach (PropertyInfo propertyInfo in customerType.GetProperties())
            {
                Console.WriteLine($"{propertyInfo.Name} - {propertyInfo.GetValue(customer)}");
            }
        }
    }
    
}