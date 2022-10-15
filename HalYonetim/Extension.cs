using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Data.EntityClient;
using System.Data.SqlClient;
using CrmPosHalYonetim.Entity;

namespace HalYonetim
{
    public static class EnumHelper<T>
    {
        public static IList<T> GetValues(Enum value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }

    public static class Extension
    {
        #region Sayıyı Yazıya Çevirme
        private static String[] birler = { "", "BİR ", "İKİ ", "ÜÇ ", "DÖRT ", "BEŞ ", "ALTI ", "YEDİ ", "SEKİZ ", "DOKUZ " };
        private static String[] onlar = { "", "ON ", "YİRMİ ", "OTUZ ", "KIRK ", "ELLİ ", "ALTMIŞ ", "YETMİŞ ", "SEKSEN ", "DOKSAN " };
        private static String[] binler = { "", "BİN ", "MİLYON ", "MİLYAR ", "TRİLYON " };

        private static String binlik(int x)
        {
            return (x >= 100 ? (x >= 200 ? birler[x / 100] : "") + "YÜZ " : "") + (x % 100 >= 10 ? onlar[((x % 100) / 10)] : "") + birler[x % 10];
        }

        private static String yaziIleEx(long x)
        {
            String str = "";
            String s = "" + x;
            int l = s.Length;//s.length(); // basamak sayisi
            int g = (int)Math.Ceiling(((decimal)l) / 3); // toplam kac tane 3 basamaktan olustugu 48,944,646 => 3
            int t = l % 3 > 0 ? l % 3 : 3; // en yuksek 3'luk grupta kac tane basamak oldugu =>2 (48)
            for (int i = g - 1; i >= 0; i--)
            {
                if (i != g - 1)
                {
                    int d = Int32.Parse(s.Substring((g - i - 2) * 3 + t, 3));
                    str += binlik(d) + (d > 0 ? binler[i] : "");
                }
                else
                {
                    int tmp;
                    String tmpstr;
                    tmpstr = s.Substring(0, t);
                    tmp = Int32.Parse(tmpstr);
                    str += (i != 1 || tmp != 1 ? binlik(tmp) : "") + binler[i];
                }
            }
            if (x == 0)
                str = "sifir";
            return str;
        }

        private static String yaziIle(decimal value)
        {
            decimal kurus = value - Math.Floor(value);
            if (kurus > 0)
                return yaziIleEx((long)Math.Floor(value)) + " TL " + yaziIleEx((long)Math.Floor(kurus * 100)) + " KRŞ";
            else
                return yaziIleEx((long)Math.Floor(value)) + " TL ";
        }

        public static string ToYaziyaCevir(this decimal value)
        {
            return "YALNIZ " + yaziIle(Math.Round(value, 2));
        }
        #endregion

        public static string EncryptData(this string Message)
        {
            const string passphrase = "password";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }

        public static string DecryptString(this string Message)
        {
            try
            {
                const string passphrase = "password";
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;
                byte[] DataToDecrypt = Convert.FromBase64String(Message);
                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                catch
                {
                    return "";
                }
                finally
                {
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }
                return UTF8.GetString(Results);
            }
            catch
            {
                return "";
            }

        }

        public static string RemoveTurkis(this string value)
        {
            return value.Replace('İ', 'I').Replace('Ü', 'U').Replace('Ç', 'C').Replace('Ş', 'S').Replace('Ö', 'O').Replace('Ğ', 'G').Replace('ı', 'i').Replace('ü', 'u').Replace('ç', 'c').Replace('ş', 's').Replace('ö', 'o').Replace('ğ', 'g');
        }

        public static string Mid(this string value, int start, int len)
        {
            if (value.Length > start + len)
            {
                return value.Substring(start, len);
            }
            else
            {
                return value.Substring(start);
            }
        }

        public static DateTime ToDatetime(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string[] part1 = value.Split(' ')[0].Split('-');
                string[] part2 = value.Split(' ')[1].Split(':');
                return new DateTime(part1[2].ToInt(), part1[1].ToInt(), part1[0].ToInt(), part2[0].ToInt(), part2[1].ToInt(), part2[2].ToInt());
            }
            else
            {
                return new DateTime(1900, 1, 1);
            }
        }

        public static string ToFormattedString(this DateTime value)
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", value.Day, value.Month, value.Year, value.Hour, value.Minute, value.Second);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static string DecimalFormat(this string value)
        {
            return "n2";
        }

        public static decimal DecimalFormat(this decimal value)
        {
            return Convert.ToDecimal(value.ToString("n2"));
        }

        public static string Assign(this string value, int len)
        {
            if (value.Length > len)
            {
                return value.Substring(0, len);
            }
            else
            {
                return value + value.Space(len - value.Length);
            }
        }

        public static string Space(this string value, int count)
        {
            string sonuc = "";
            for (int i = 0; i < count; i++)
            {
                sonuc += " ";
            }
            return sonuc;
        }

        public static T TolerantCast<T>(this object o, T example) where T : class
        {
            if (o == null)
            {
                return null;
            }
            IComparer<string> comparer = StringComparer.CurrentCultureIgnoreCase;
            //Get constructor with lowest number of parameters and its parameters 
            var constructor = typeof(T).GetConstructors(
               BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
            ).OrderBy(c => c.GetParameters().Length).First();
            var parameters = constructor.GetParameters();

            //Get properties of input object
            var sourceProperties = new List<PropertyInfo>(o.GetType().GetProperties());

            if (parameters.Length > 0)
            {
                var values = new object[parameters.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    Type t = parameters[i].ParameterType;
                    //See if the current parameter is found as a property in the input object
                    var source = sourceProperties.Find(delegate(PropertyInfo item)
                    {
                        return comparer.Compare(item.Name, parameters[i].Name) == 0;
                    });

                    //See if the property is found, is readable, and is not indexed
                    if (source != null && source.CanRead &&
                       source.GetIndexParameters().Length == 0)
                    {
                        //See if the types match.
                        if (source.PropertyType == t)
                        {
                            //Get the value from the property in the input object and save it for use
                            //in the constructor call.
                            values[i] = source.GetValue(o, null);
                            continue;
                        }
                        else
                        {
                            //See if the property value from the input object can be converted to
                            //the parameter type
                            try
                            {
                                values[i] = Convert.ChangeType(source.GetValue(o, null), t);
                                continue;
                            }
                            catch
                            {
                                //Impossible. Forget it then.
                            }
                        }
                    }
                    //If something went wrong (i.e. property not found, or property isn't 
                    //converted/copied), get a default value.
                    values[i] = t.IsValueType ? Activator.CreateInstance(t) : null;
                }
                //Call the constructor with the collected values and return it.
                return (T)constructor.Invoke(values);
            }
            //Call the constructor without parameters and return the it.
            return (T)constructor.Invoke(null);
        }

        public static T ToAnonymousType<T>(this object obj, T prototype) where T : class
        {
            T atiObj = obj as T;
            if (atiObj == null)
            {
                //atiObj = GetTypeInstance(obj, prototype.GetType()) as T;
            }
            return (atiObj);
        }
        public static T Cast<T>(T type, object obj) where T : class
        {
            return (T)obj;
        }
        public static List<T> CastToList<T>(this object obj, T prototype) where T : class
        {
            List<T> list = new List<T>();
            IEnumerable<T> enumerable = obj as IEnumerable<T>;
            if (enumerable != null)
            {
                list.AddRange(enumerable);
            }
            else
            {
                IEnumerable enumObjects = obj as IEnumerable;
                if (enumObjects == null)
                {
                    return null;
                }
                foreach (object enumObject in enumObjects)
                {
                    T currObject = ToAnonymousType(enumObject, prototype);

                    if (currObject == null)
                    {
                        list.Clear();
                        return list;
                    }
                    list.Add(currObject);
                }
            }
            return list;
        }

        public static T Clone<T>(this object o)
        {
            var newEntityObject = o.GetType().GetConstructor(new Type[0]).Invoke(new object[0]);
            FieldInfo[] myObjectFields = o.GetType().GetFields(
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(newEntityObject, fi.GetValue(o));
            }
            return (T)newEntityObject;
        }

        public static Image ResizeBitmap(this Image b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }

        public static bool Like(this string s, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            pattern = Regex.Escape(pattern.Replace('*', '%'));
            pattern = pattern.Replace("%", ".*?").Replace("_", ".");
            pattern = pattern.Replace(@"\[", "[").Replace(@"\]", "]").Replace(@"\^", "^");
            return Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
        }

        public static EntityConnection GetEntityConnection(this EntityConnection source)
        {
            string serverName = DbSettings.Instance.GetValue(DbSettingsEnum.SunucuAdi);
            string databaseName = DbSettings.Instance.GetValue(DbSettingsEnum.Veritabani);
            string providerName = "System.Data.SqlClient";
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.MultipleActiveResultSets = true;
            if (DbSettings.Instance.GetValue(DbSettingsEnum.OturumAcmaSekli) == "SQL")
            {
                sqlBuilder.UserID = DbSettings.Instance.GetValue(DbSettingsEnum.KullaniciAdi);
                sqlBuilder.Password = DbSettings.Instance.GetValue(DbSettingsEnum.Sifre);
                sqlBuilder.IntegratedSecurity = false;
            }
            else
                sqlBuilder.IntegratedSecurity = true;

            string providerString = sqlBuilder.ToString();
            EntityConnectionStringBuilder entitycon = new EntityConnectionStringBuilder();
            entitycon.Provider = providerName;
            entitycon.ProviderConnectionString = providerString;
            entitycon.Metadata = @"res://*/Entity.HKSMODEL.csdl|res://*/Entity.HKSMODEL.ssdl|res://*/Entity.HKSMODEL.msl";
            source.ConnectionString = entitycon.ToString();
            return source;
        }
       
    }
    public class GetDatabaseDbSettings
    {
        private static GetDatabaseDbSettings _instance;

        public static GetDatabaseDbSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GetDatabaseDbSettings();
                }
                return GetDatabaseDbSettings._instance;
            }
        }

        public HKSDBEntities GetEntity()
        {
            HKSDBEntities ent = new HKSDBEntities(new EntityConnection().GetEntityConnection());
            return ent;

        }
    }
}
