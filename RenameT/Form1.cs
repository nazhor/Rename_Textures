using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenameT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BT_Rename_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("probando");
            if (TB_Name.Text == "")
                MessageBox.Show("Que no has puesto noooombre");
            else
            {
                string[] fileEntries = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
                string newNameTexture = TB_Name.Text;

                foreach (string fileNameOld in fileEntries)
                {
                    if (fileNameOld.Contains(".png"))
                    {
                        if ((fileNameOld.Contains("Basecolor")) ||
                            (fileNameOld.Contains("BaseColor")))
                        {
                            Renombrar(fileNameOld, newNameTexture, "_BaseColor.png");
                        }
                        else if (fileNameOld.Contains("Emissive"))
                        {
                            Renombrar(fileNameOld, newNameTexture, "_Emissive.png");
                        }
                        else if (fileNameOld.Contains("Normal"))
                        {
                            Renombrar(fileNameOld, newNameTexture, "_Normal.png");
                        }
                        else if (fileNameOld.Contains("OcclusionRoughnessMetallic"))
                        {
                            Renombrar(fileNameOld, newNameTexture, "_ORM.png");
                        }
                        else if (fileNameOld.Contains("Ambient_occlusion"))
                        {
                            Renombrar(fileNameOld, newNameTexture, "_AmbientOcclusion.png");
                        }
                        else if (fileNameOld.Contains("Metallic"))
                        {
                            Renombrar(fileNameOld, newNameTexture, "_Metallic.png");
                        }
                        else if (fileNameOld.Contains("Roughness"))
                        {
                            Renombrar(fileNameOld, newNameTexture, "_Roughness.png");
                        }
                        else if (fileNameOld.Contains("Specular"))
                        {
                            Renombrar(fileNameOld, newNameTexture, "_Specular.png");
                        }
                    }                    
                }
            }


        }

        //Función para renombrar un fichero
        private static void Renombrar(string pOld, string pNew, string pType)
        {
            int startIndex = pOld.LastIndexOf('\\');
            string pth = pOld.Substring(0, startIndex + 1);
            string fileNameNew = pth + pNew + pType;
            try
            {
                System.IO.File.Move(pOld, fileNameNew);
            }
            catch
            {
                string msg = "Error al renombrar la textura " + pNew + pType + " ¿Puede ser que ya exista una con ese nombre en la carpeta destino?";
                MessageBox.Show(msg, "Algo no va bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
