using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;
using Utils;

namespace DataAccess
{
    public class DAO
    {
        protected internal static List<T> DataTableToObjectList<T>(DataTable objectTable)
        {
            List<T> oneList = new List<T>();
            foreach (DataRow row in objectTable.Rows)
            {
                T obj = loadObject<T>(row);
                oneList.Add(obj);
            }

            return oneList;
        }

        protected internal static T DataTableToObject<T>(DataTable objectTable)
        {
            T obj = default(T);

            if (objectTable.Rows.Count > 0)
             obj = loadObject<T>(objectTable.Rows[0]);

            return obj;
        }

        private static T loadObject<T>(DataRow row)
        {
            Type objectType = typeof(T);
            T obj = default(T);
            obj = (T)Activator.CreateInstance(objectType);

            //PropertyInfo[] pi = objectType.GetProperties((BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            //    .Where(p => Attribute.IsDefined(p, typeof(DataMemberAttribute))).ToArray<PropertyInfo>();

            foreach (var columna in row.Table.Columns)
            {
                PropertyInfo[] propiedadesDelObjeto = objectType.GetProperties().ToArray<PropertyInfo>();
                
                foreach (PropertyInfo propiedadObjetoT in propiedadesDelObjeto)
                {
                    if (propiedadObjetoT.Name == columna.ToString())
                    {
                        if(!propiedadObjetoT.IsSpecialName)
                        {
                            //No es specialName y tiene el mismo nombre => atroden
                            propiedadObjetoT.SetValue(obj, Convert.ChangeType(row[propiedadObjetoT.Name], Type.GetType(propiedadObjetoT.PropertyType.FullName)), null);
                            break;
                        }
                        else
                        {
                            //La columna del DataTable tiene el mismo nombre de la propiedad, pero es specialName
                            //Hay que buscar la relacion
                            object[] attrRelation = propiedadObjetoT.GetCustomAttributes(typeof(RelationDataAttribute), true);

                            if (attrRelation.Length > 0)
                            {
                                Type tipoInterno = propiedadObjetoT.PropertyType;

                                PropertyInfo[] propiedadesObjetoInterno = tipoInterno.GetProperties().ToArray<PropertyInfo>();

                                var lalala = propiedadObjetoT.GetValue(obj);

                                if(lalala == null)
                                {
                                    var objInterno = Activator.CreateInstance(propiedadObjetoT.PropertyType);

                                    foreach (var propiedadInterna in propiedadesObjetoInterno)
                                    {
                                        object[] attrKeyData = propiedadInterna.GetCustomAttributes(typeof(KeyDataAttribute), true);

                                        if (attrKeyData.Length > 0)
                                        {
                                            propiedadInterna.SetValue(objInterno, row[columna.ToString()]);

                                            propiedadObjetoT.SetValue(obj, objInterno);
                                            break;
                                        }

                                        //if (propiedadInterna.Name == columna.ToString() || propiedadObjetoT.Name == columna.ToString())
                                        //{
                                        //    propiedadInterna.SetValue(objInterno, row[columna.ToString()]);

                                        //    propiedadObjetoT.SetValue(obj, objInterno);
                                        //    break;
                                        //}

                                    }
                                }
                                else
                                {
                                    foreach (var propiedadInterna in propiedadesObjetoInterno)
                                    {
                                        object[] attrKeyData = propiedadInterna.GetCustomAttributes(typeof(KeyDataAttribute), true);

                                        if (attrKeyData.Length > 0)
                                        {
                                            propiedadInterna.SetValue(lalala, row[columna.ToString()]);

                                            propiedadObjetoT.SetValue(obj, lalala);
                                            break;
                                        }

                                        //if (propiedadInterna.Name == columna.ToString() || propiedadObjetoT.Name == columna.ToString())
                                        //{
                                        //    propiedadInterna.SetValue(objInterno, row[columna.ToString()]);

                                        //    propiedadObjetoT.SetValue(obj, objInterno);
                                        //    break;
                                        //}

                                    }
                                }

                                
                            }
                        }                       
                    }
                    else
                    {
                        //La columna del DataTable no tiene el mismo nombre que la propiedad

                        //Vemos si tiene nombre alternativo
                        object[] attrAlternative = propiedadObjetoT.GetCustomAttributes(typeof(AlternativeNameAttribute), true);

                        if (attrAlternative.Length > 0)
                        {
                            //Tiene nombre alternativo
                            AlternativeNameAttribute atributo = (AlternativeNameAttribute)attrAlternative[0];

                            if (columna.ToString() == atributo.alternativeName)
                            {
                                propiedadObjetoT.SetValue(obj, Convert.ChangeType(row[atributo.alternativeName], Type.GetType(propiedadObjetoT.PropertyType.FullName)), null);
                                //cargado = true;
                                break;
                            }
                        }
                        else
                        {
                            //No tiene nombre alternativo
                            object[] attrRelation = propiedadObjetoT.GetCustomAttributes(typeof(RelationDataAttribute), true);

                            if (attrRelation.Length > 0)
                            {
                                //Es atributo con relacion de otra clase
                                if (((RelationDataAttribute)attrRelation[0]).Atributte == columna.ToString())
                                {
                                    //El atributo en relacion tiene el mismo nombre que la columna del DataTable
                                    Type tipoInterno = propiedadObjetoT.PropertyType;

                                    PropertyInfo[] propiedadesObjetoInterno = tipoInterno.GetProperties().ToArray<PropertyInfo>();

                                    var lalala = propiedadObjetoT.GetValue(obj);

                                    if(lalala == null)
                                    {
                                        var objInterno = Activator.CreateInstance(propiedadObjetoT.PropertyType);

                                        foreach (var propiedadInterna in propiedadesObjetoInterno)
                                        {
                                            if (propiedadInterna.Name == columna.ToString())
                                            {
                                                propiedadInterna.SetValue(objInterno, row[columna.ToString()]);

                                                propiedadObjetoT.SetValue(obj, objInterno);
                                                break;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        foreach (var propiedadInterna in propiedadesObjetoInterno)
                                        {
                                            if (propiedadInterna.Name == columna.ToString())
                                            {
                                                propiedadInterna.SetValue(lalala, row[columna.ToString()]);

                                                propiedadObjetoT.SetValue(obj, lalala);
                                                break;
                                            }

                                        }
                                    }
                                }
                            }

                            //else
                            //{
                                //No tiene relacion ni tiene alternativeName
                                if(propiedadObjetoT.IsSpecialName)
                                {
                                    Type tipoInterno = propiedadObjetoT.PropertyType;

                                    PropertyInfo[] propiedadesObjetoInterno = tipoInterno.GetProperties().ToArray<PropertyInfo>();

                                    var lalala = propiedadObjetoT.GetValue(obj);

                                    if(lalala == null)
                                    {
                                        var objInterno = Activator.CreateInstance(propiedadObjetoT.PropertyType);

                                        foreach (var propiedadInterna in propiedadesObjetoInterno)
                                        {
                                            if (propiedadInterna.Name == columna.ToString())
                                            {
                                                propiedadInterna.SetValue(objInterno, row[columna.ToString()]);

                                                propiedadObjetoT.SetValue(obj, objInterno);
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach (var propiedadInterna in propiedadesObjetoInterno)
                                        {
                                            if (propiedadInterna.Name == columna.ToString())
                                            {
                                                propiedadInterna.SetValue(lalala, row[columna.ToString()]);

                                                propiedadObjetoT.SetValue(obj, lalala);
                                                break;
                                            }
                                        }
                                    }
                                    
                                }                                
                            //}
                        }

                        //if(propiedadObjetoT.IsSpecialName)
                        //{
                            //object[] attrRelation = propiedadObjetoT.GetCustomAttributes(typeof(RelationDataAttribute), true);

                            //if (attrRelation.Length > 0)
                            //{
                            //    if (((RelationDataAttribute)attrRelation[0]).Atributte == columna.ToString())
                            //    {
                            //        Type tipoInterno = propiedadObjetoT.PropertyType;

                            //        PropertyInfo[] propiedadesObjetoInterno = tipoInterno.GetProperties().ToArray<PropertyInfo>();
                            //        var objInterno = Activator.CreateInstance(propiedadObjetoT.PropertyType);

                            //        foreach (var propiedadInterna in propiedadesObjetoInterno)
                            //        {
                            //            if (propiedadInterna.Name == columna.ToString())
                            //            {
                            //                propiedadInterna.SetValue(objInterno, row[columna.ToString()]);

                            //                propiedadObjetoT.SetValue(obj, objInterno);
                            //                break;
                            //            }

                            //        }

                            //    }

                            //}
                        //}                       
                     
                    }

                       
                    
                }
            }

            //PropertyInfo[] pi = objectType.GetProperties().ToArray<PropertyInfo>();
            //T obj = (T)Activator.CreateInstance(objectType);

            //foreach (PropertyInfo infoElement in pi)
            //{
            //    if(!infoElement.IsSpecialName)
            //    {
            //        if (row.Table.Columns.Contains(infoElement.Name))
            //        {
            //            if (row[infoElement.Name] == DBNull.Value)
            //            {
            //                infoElement.SetValue(obj, null, null);
            //            }
            //            else
            //            {
            //                infoElement.SetValue(obj, Convert.ChangeType(row[infoElement.Name], Type.GetType(infoElement.PropertyType.FullName)), null);
            //            }
            //        }
            //        else
            //        {
            //            //Vemos si el objeto define un alternativeName para el atributo
            //            object[] attrs = infoElement.GetCustomAttributes(typeof(AlternativeNameAttribute), true);
                        
            //            if(attrs.Length > 0)
            //            {
            //                AlternativeNameAttribute atributo = (AlternativeNameAttribute)attrs[0];

            //                if(row.Table.Columns.Contains(atributo.alternativeName))
            //                {
            //                    infoElement.SetValue(obj, Convert.ChangeType(row[atributo.alternativeName], Type.GetType(infoElement.PropertyType.FullName)), null);
            //                }
            //                else
            //                {
            //                    infoElement.SetValue(obj, null, null);
            //                }
            //            }
            //            else
            //            {
            //                infoElement.SetValue(obj, null, null);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        object[] attrs = infoElement.GetCustomAttributes(typeof(RelationDataAttribute), true);
                    
            //        foreach (RelationDataAttribute item in attrs)
            //        {
            //            if (item != null)
            //            {
            //                Type tipoInterno = infoElement.PropertyType;

            //                PropertyInfo[] propiedadesInterno = tipoInterno.GetProperties().ToArray<PropertyInfo>();

            //                foreach (var propiedadInterna in propiedadesInterno)
            //                {
            //                    if (propiedadInterna.Name == item.Atributte)
            //                    {
            //                        if (row.Table.Columns.Contains(infoElement.Name))
            //                        {
            //                            var objInterno = Activator.CreateInstance(infoElement.PropertyType);

            //                            propiedadInterna.SetValue(objInterno, row[infoElement.Name]);

            //                            infoElement.SetValue(obj, objInterno);
            //                            break;
            //                        }                                   
            //                    }
            //                    else
            //                    {
            //                        object[] attrAlternative = propiedadInterna.GetCustomAttributes(typeof(AlternativeNameAttribute), true);

            //                        if (attrAlternative.Length > 0)
            //                        {
            //                            AlternativeNameAttribute atributo = (AlternativeNameAttribute)attrAlternative[0];

            //                            if (item.Atributte == atributo.alternativeName)
            //                            {
            //                                //infoElement.SetValue(obj, Convert.ChangeType(row[atributo.alternativeName], Type.GetType(infoElement.PropertyType.FullName)), null);
            //                                if(row.Table.Columns.Contains(item.Atributte))
            //                                {
            //                                    var objInterno = Activator.CreateInstance(infoElement.PropertyType);

            //                                    propiedadInterna.SetValue(objInterno, row[infoElement.Name]);

            //                                    infoElement.SetValue(obj, objInterno);
            //                                    break;
            //                                }                                           
            //                            }                                        
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
        
            //}

            return obj;
        }

    }
}
