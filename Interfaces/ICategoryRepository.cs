﻿using EKGMaster.Models.ProductStuff;

namespace EKGMaster.Interfaces
{
    public interface ICategoryRepository<T>
    {
        public T GetOne(T t);

        public T Add(T t);

        public void Update(T t);

        public void Delete(T t);

        public T GetNewestItem();
    }
}
