//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LadaAutoApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Автомобили
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Автомобили()
        {
            this.Продажи = new HashSet<Продажи>();
        }
    
        public int Код { get; set; }
        public string Модель { get; set; }
        public string Цвет { get; set; }
        public string Комплектации { get; set; }
        public Nullable<decimal> Цена { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Продажи> Продажи { get; set; }
    }
}
