using System;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class FormSocket : Form
    {
        private Client clientSocket;

        public FormSocket()
        {
            InitializeComponent();
            clientSocket = new Client("127.0.0.1", 9999);
            clientSocket.StartListening(AfficherMessage); // Commencer à écouter les données du serveur
            buttonSend.Click += buttonSend_Click;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            // Récupérer le contenu de richTextBoxInput
            string messageToSend = richTextBoxInput.Text;

            // Envoyer le message au serveur via le client socket
            clientSocket.Send(messageToSend);

            // Effacer le contenu de richTextBoxInput après l'envoi
            richTextBoxInput.Clear();
        }

        // Méthode pour afficher un message dans le contrôle TextBox
        private void AfficherMessage(string message)
        {
            if (richTextBoxOutput.InvokeRequired)
            {
                richTextBoxOutput.Invoke((Action)(() => AfficherMessage(message)));
            }
            else
            {
                richTextBoxOutput.AppendText(message + Environment.NewLine);
            }
        }
    }
}
