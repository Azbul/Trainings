using System;

namespace Inheritance.DataStructure
{
    public class Category : IComparable
    {
        public Category(string product, MessageType messageType, MessageTopic messageTopic)
        {
            ProductName = product;
            MessageType = messageType;
            MessageTopic = messageTopic;
        }

        public string ProductName { get; set; }

        public MessageType MessageType { get; set; }

        public MessageTopic MessageTopic { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            var category = obj as Category;
            var prNameComp = ProductName == null
                ? -1
                : category.ProductName == null
                ? 1
                : ProductName.CompareTo(category.ProductName);

            // лучше использовать метод string.Compare. Данный статический метод возвращает значение даже если передать нулл
            var prNameComp2 = string.Compare(ProductName, category.ProductName);

            var msgTypeComp = MessageType.CompareTo(category.MessageType);
            return prNameComp == 0 
                ? msgTypeComp == 0 
                ? MessageTopic.CompareTo(category.MessageTopic) 
                : msgTypeComp 
                : prNameComp;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType())) return false;
            var category = obj as Category;
            return ProductName == category.ProductName
                && MessageType == category.MessageType
                && MessageTopic == category.MessageTopic;
        }

        public override int GetHashCode()
        {
            return Math.Abs(ProductName.GetHashCode()) 
                 + Math.Abs(MessageType.ToString().GetHashCode()) 
                 + Math.Abs(MessageTopic.ToString().GetHashCode());
        }

        public override string ToString()
        {
            return $"{ProductName}.{MessageType}.{MessageTopic}";
        }

        public static bool operator >(Category c1, Category c2)
        {
            return c1.CompareTo(c2) == 1;
        }

        public static bool operator <(Category c1, Category c2)
        {
            return c1.CompareTo(c2) == -1;
        }

        public static bool operator >=(Category c1, Category c2)
        {
            var comRes = c1.CompareTo(c2);
            return comRes == 1 || comRes == 0;
        }

        public static bool operator <=(Category c1, Category c2)
        {
            var comRes = c1.CompareTo(c2);
            return comRes == 0 || comRes == -1;
        }
    }
}
