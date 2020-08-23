using System;

namespace availability.application.exceptions {
    public abstract class AppException: Exception {
        public virtual string Code {get;}
        protected AppException(string message): base(message) {
            
        }

    }
}