using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinForms.Classes
{
    static public class CloneGenerator
    {
        public static object DeepClone(object objSource)
        {
            //using (var ms = new MemoryStream())
            //{
            //    var formatter = new BinaryFormatter();
            //    formatter.Serialize(ms, obj);
            //    ms.Position = 0;

            //    return (T)formatter.Deserialize(ms);
            //}

            //Type tObj = objSource.GetType();
            //var constructor = tObj.GetConstructor(Type.EmptyTypes);
            //if (constructor == null)
            //{
            //    return objSource;
            //}
            //object objTarget = Activator.CreateInstance(tObj);
            //PropertyInfo[] propertyInfo = tObj.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //foreach (PropertyInfo property in propertyInfo)
            //{
            //    if (property.CanWrite)
            //    {
            //        if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(String)))
            //        {
            //            property.SetValue(objTarget, property.GetValue(objSource, null), null);
            //        }
            //        else
            //        {
            //            object objPropertyValue = property.GetValue(objSource, null);
            //            if (objPropertyValue == null)
            //            {
            //                property.SetValue(objTarget, null, null);
            //            }
            //            else
            //            {
            //                property.SetValue(objTarget, DeepClone(objPropertyValue), null);
            //            }
            //        }
            //    }
            //}
            //return objTarget;
            return null;
        }


        static public Button CloneButton(this Button btn)
        {
            object tag = Activator.CreateInstance(btn.Tag.GetType(), btn.Tag);
            Point loc = new Point(btn.Location.X, btn.Location.Y);
            Size sz = new Size(btn.Size.Width, btn.Size.Height);
            Button clone = new Button();
            clone.Tag = tag;
            clone.Location = loc;
            clone.Size = sz;

            return clone;
        }
    }
}
