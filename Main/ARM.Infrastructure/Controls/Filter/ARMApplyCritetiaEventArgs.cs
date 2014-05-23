using System;

namespace ARM.Infrastructure.Controls.Filter
{
    /// <summary>
    /// Класс аргументів, що передає назву властивості, яка повинна фільтруватисьь та значення за яким проходить фільтрування.
    /// Якщо значення рівне NULL або пусто, то критерія видалиться з колекції.
    /// </summary>
    public class ARMApplyCritetiaEventArgs :  EventArgs
    {
        public ARMApplyCritetiaEventArgs()
        {
        }

        public string PropertyName { get; set; }
        public string Value { get; set; }
 
    }
}