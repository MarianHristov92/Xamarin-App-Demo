using System;
using System.Collections.Generic;
using DemoAppBackendApi.Base.Models;

namespace DemoAppBackendApi.Base.Data
{
    public class BaseApiFeedData
    {

        public static IList<BaseFeedItem> BaseDataList { get; private set; }

        static BaseApiFeedData()
        {
            BaseDataList = new List<BaseFeedItem>();

            BaseDataList.Add(new BaseFeedItem
            {
                Id = "001",
                FeedItemImageUrl = "https://static.wixstatic.com/media/ae3f48_316fbcde031c47e8842321237971c38d~mv2.jpg/v1/fill/w_457,h_315,al_c,q_80,usm_0.66_1.00_0.01/IMG06114.webp",
                FeedItemText = "Balkan Bar and Grill",
                LinkUrl = "https://www.balkanbarandgrill.com/"
            });

            BaseDataList.Add(new BaseFeedItem
            {
                Id = "002",
                FeedItemImageUrl = "https://static.wixstatic.com/media/ae3f48_62c5e4af3794472fbb14979414cd4a5a~mv2_d_6000_4000_s_4_2.jpg/v1/fill/w_1118,h_745,al_c,q_85,usm_0.66_1.00_0.01/ae3f48_62c5e4af3794472fbb14979414cd4a5a~mv2_d_6000_4000_s_4_2.webp",
                FeedItemText = "Crystall Hall Banquet Halls",
                LinkUrl = "https://www.crystal-hall-banquets.com/"
            });

            BaseDataList.Add(new BaseFeedItem
            {
                Id = "003",
                FeedItemImageUrl = "https://images.squarespace-cdn.com/content/v1/5ba5d4bce5f7d1371dd93916/1538330115654-1V19SYVKRS6IX5P1VVG0/ke17ZwdGBToddI8pDm48kDFgITcRoterXoQdllT5ciUUqsxRUqqbr1mOJYKfIPR7LoDQ9mXPOjoJoqy81S2I8N_N4V1vUb5AoIIIbLZhVYxCRW4BPu10St3TBAUQYVKcV7ZyRJyI8bwZiMJRrgPaAKqUaXS0tb9q_dTyNVba_kClt3J5x-w6oTQbPni4jzRa/coming+soon.jpg?format=1500w",
                FeedItemText = "LK Service",
                LinkUrl = ""
            });
        }
    }
}
