//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatMessenger.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChatMessage
    {
        public int Id_ChatMessage { get; set; }
        public int Id_Employee { get; set; }
        public int Id_Chatroom { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Message { get; set; }
    
        public virtual Chatroom Chatroom { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
