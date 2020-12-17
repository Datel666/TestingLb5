using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingLb1;

namespace Testing5Web.Repository
{
    public class GoodsStoreContainer : IGoodsStoreContainer
    {
        private readonly GoodsStore _gs;

        public GoodsStoreContainer()
        {
            _gs = new GoodsStore();
        }

        public GoodsStore GetGoodsStore()
        {
            return _gs;
        }
    }
}
