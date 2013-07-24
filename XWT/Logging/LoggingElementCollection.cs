using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace XWT.Logging {
    public class LoggingElementCollection : ConfigurationElementCollection {
        public LoggingElementCollection() {
            LoggingElement myElement = (LoggingElement)CreateNewElement();
            Add(myElement);
        }
        public void Add(LoggingElement customElement) {
            BaseAdd(customElement);
        }

        protected override void BaseAdd(ConfigurationElement element) {
            base.BaseAdd(element, false);
        }

        public override ConfigurationElementCollectionType CollectionType {
            get {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement() {
            return new LoggingElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((LoggingElement)element).Name;
        }

        public LoggingElement this[int Index] {
            get {
                return (LoggingElement)BaseGet(Index);
            }
            set {
                if (BaseGet(Index) != null) {
                    BaseRemoveAt(Index);
                }
                BaseAdd(Index, value);
            }
        }

        new public LoggingElement this[string Name] {
            get {
                return (LoggingElement)BaseGet(Name);
            }
        }

        public int indexof(LoggingElement element) {
            return BaseIndexOf(element);
        }

        public void Remove(LoggingElement url) {
            if (BaseIndexOf(url) >= 0)
                BaseRemove(url.Name);
        }

        public void RemoveAt(int index) {
            BaseRemoveAt(index);
        }

        public void Remove(string name) {
            BaseRemove(name);
        }

        public void Clear() {
            BaseClear();
        }

    }
}
