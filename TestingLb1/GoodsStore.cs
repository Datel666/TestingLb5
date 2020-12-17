using System;
using System.Collections.Generic;
using System.Text;

namespace TestingLb1
{
    public class GoodsStore
    {

        private List<Product> _products;


        public IReadOnlyCollection<Product> Products => _products;

        public GoodsStore()
        {
            _products = new List<Product>();
        }


        public int Count => _products.Count;

        


        public void AddNewProduct(Product product)
        {
            if(int.TryParse(product.count,out int n) && int.TryParse(product.price,out int nn))
            {
                if(!_products.Contains(product))
                {
                    _products.Add(product);
                }
                else
                {
                    throw new Exception("Item already exist");
                }
            }
            else
            {
                throw new Exception("Wrong inputs");
            }
            
        }

        public void ImportProduct(string name, string count)
        {
            if(int.TryParse(count, out int nn))
            {
                try
                {
                    int id = _products.FindIndex(a => a.name == name);
                    _products[id].count = (Convert.ToInt32(_products[id].count) + Convert.ToInt32(count)).ToString();
                }
                catch
                {
                    throw new Exception("Item not found");
                }
            }
            else
            {
                throw new Exception("Wrong inputs");
            }
        }

        public void BuyProduct(string name, string count)
        {
            if (int.TryParse(count, out int nn))
            {
                try
                {
                    int id = _products.FindIndex(a => a.name == name);
                    _products[id].count = (Convert.ToInt32(_products[id].count) - Convert.ToInt32(count)).ToString();
                }
                catch
                {
                    throw new Exception("Item not found");
                }
            }
            else
            {
                throw new Exception("Wrong inputs");
            }
        }

        public bool Exists(Product product)
        {
            return _products.Contains(product);
        }

        public void RemoveIfExists(Product product)
        {
            _products.Remove(product);
        }

        public void RemoveAllWithName(string name)
        {
            var count = _products.FindAll(a => a.name == name).Count;
            if (count > 0)
            {
                foreach (var pr in _products.FindAll(a => a.name == name))
                {
                    _products.Remove(pr);
                }
            }
            else
            {
                throw new Exception("Item not found");
            }
        }


    }
    
}
