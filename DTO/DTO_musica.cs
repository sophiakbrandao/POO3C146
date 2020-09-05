using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO3C146.DTO
{
    class DTO_musica
    {
        private int idmusica, idgravadora, idCD;
        private string nome, nomeautor;

        public int Idmusica { get => idmusica; set => idmusica = value; }
        public int Idgravadora { get => idgravadora; set => idgravadora = value; }
        public int IdCD { get => idCD; set => idCD = value; }


        public string Nome
        {
            set
            {
                if (value != string.Empty)
                {
                    this.nome = value;
                }
                else
                {
                    throw new Exception("O nome da música é obrigatório.");
                }

            }
            get { return this.nome; }
        }

        public string NomeAutor
        {
            set
            {
                if (value != string.Empty)
                {
                    this.nomeautor = value;
                }
                else
                {
                    throw new Exception("O nome do autor é obrigatório.");
                }

            }
            get { return this.nomeautor; }
        }


    }
}
