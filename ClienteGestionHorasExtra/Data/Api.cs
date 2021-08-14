using ClienteGestionHorasExtra.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Data
{
    public class Api
    {
        private string URL_API = "";
        public Api(string url)
        {
            URL_API = url;
        }

        public string ConnectPOST(string objeto, string Base2)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            URL_API + Base2,
                            new StringContent(objeto, Encoding.UTF8, "application/json")
                            );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "Ya hay un registro con esa informacion";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "No se encontro el recurso";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string InicioSesion(string objeto, string Base2)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            URL_API + Base2,
                            new StringContent(objeto, Encoding.UTF8, "application/json")
                            );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        //Persona p = JsonConvert.DeserializeObject<Persona>(mens);
                        string[] data = mens.Split(',');
                        return "1," + data[0] + "," + data[1] + "," + data[2];
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "Ya hay un registro con esa informacion";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string CerrarSesion(string objeto, string Base2)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            URL_API + Base2,
                            new StringContent(objeto, Encoding.UTF8, "application/json")
                            );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "Ya hay un registro con esa informacion";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ModelTarea> ObtenerTareas(string email, string Base2)
        {
            try
            {
                List<ModelTarea> lista = null;

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(URL_API + Base2 + "?email=" + email);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        var task1 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task1.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return lista;

                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        lista = JsonConvert.DeserializeObject<List<ModelTarea>>(mens);

                    }
                    return lista;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ModelTarea> ObtenerSolicitudesTareas(string Base2)
        {
            try
            {
                List<ModelTarea> lista = null;

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(URL_API + Base2);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        var task1 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task1.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return lista;

                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        lista = JsonConvert.DeserializeObject<List<ModelTarea>>(mens);

                    }
                    return lista;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Persona> ObtenerFuncionarios(string Base2)
        {
            try
            {
                List<Persona> lista = null;

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(URL_API + Base2);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        var task1 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task1.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return lista;

                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        lista = JsonConvert.DeserializeObject<List<Persona>>(mens);

                    }
                    return lista;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ModelFormularioAvalado> ObtenerFormulariosAvalados(string email, string Base2)
        {
            try
            {
                List<ModelFormularioAvalado> lista = null;

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(URL_API + Base2 + "?email=" + email);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        var task1 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task1.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return lista;

                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        lista = JsonConvert.DeserializeObject<List<ModelFormularioAvalado>>(mens);

                    }
                    return lista;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string AceptarSolicitud(string motivo, string Base2)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            URL_API + Base2 + "?motivo=" + motivo, null);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "Ya hay un registro con esa informacion";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "No se encontro el recurso";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string ConnectDELETE(string Base2, string codigo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.DeleteAsync(
                            URL_API + Base2 + "?id=" + codigo);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El Registro no se encuentra en la base de datos";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string ConnectPUT(string objeto, string Base2, string codigo)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PutAsync(
                            URL_API + Base2 + "?id=" + codigo,
                            new StringContent(objeto, Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El Registro no se encuentra en nuestra Base de datos";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
