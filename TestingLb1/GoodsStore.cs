using System;
using System.Collections.Generic;
using System.Text;

namespace TestingLb1
{
    public class GoodsStore
    {
        private List<Product> _products;
        public string errorText;

        public IReadOnlyCollection<Product> Products => _products;

        public GoodsStore()
        {
            _products = new List<Product>();
        }

        public int Count => _products.Count;

        public void AddNewProduct(Product product)
        {
            if (!(product.name == null))
            {
                if (!_products.Exists(a => a.name == product.name))
                {
                    if (uint.TryParse(product.count, out uint n) && uint.TryParse(product.price, out uint nn) && !(product.count == null) && !(product.price == null))
                    {
                        _products.Add(product);
                        errorText = "";
                    }
                    else
                    {
                        errorText = "Count_and_Price_is_Negative_or_NotNumber";
                    }
                }
                else
                {
                    errorText = "Item_already_exist";
                }
            }
            else
            {
                errorText = "ItemName_IsNull";
            }

        }

        public void ImportProduct(string name, string count)
        {
            if (!(name == null))
            {
                int id = _products.FindIndex(a => a.name == name);
                if (id >= 0)
                {
                    if (uint.TryParse(count, out uint nn) && !(count == null))
                    {
                        _products[id].count = (Convert.ToInt32(_products[id].count) + Convert.ToInt32(count)).ToString();
                        errorText = "";
                    }

                    else
                    {
                        errorText = "Wrong_count";
                    }

                }
                else
                {
                    errorText = "Item_not_found";
                }
            }
            else
            {
                errorText = "ItemName_IsNull";
            }

        }

        public void BuyProduct(string name, string count)
        {
            if (!(name == null))
            {
                int id = _products.FindIndex(a => a.name == name);
                if (id >= 0)
                {
                    if (uint.TryParse(count, out uint nn) && !(count == null))
                    {
                        if (Convert.ToInt32(_products[id].count) >= Convert.ToInt32(count))
                        {
                            _products[id].count = (Convert.ToInt32(_products[id].count) - Convert.ToInt32(count)).ToString();
                            errorText = "";
                        }
                        else
                        {
                            errorText = "Item_buy_query_count_more_than_exist";
                        }
                    }
                    else
                    {
                        errorText = "Wrong_count";
                    }
                }
                else
                {
                    errorText = "Item_not_found";
                }
            }
            else
            {
                errorText = "ItemName_IsNull";
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
            if (!(name == null))
            {

                var count = _products.FindAll(a => a.name == name).Count;
                if (count > 0)
                {
                    foreach (var pr in _products.FindAll(a => a.name == name))
                    {
                        _products.Remove(pr);
                        errorText = "";
                    }
                }
                else
                {
                    errorText = "Item_not_found";
                }
            }
            else
            {
                errorText = "ItemName_IsNull";
            }
        }
    }

}
