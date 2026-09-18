using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quiz_Game_WPF_MOO_ICT
{
    /// <summary>
    /// Interação lógica para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // cria uma nova lista de inteiros chamada questionNumbers que conterá os números das questões do quiz
        // esses inteiros serão usados para controlar qual questão será exibida na tela
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        // cria 3 variáveis inteiras chamadas qNum, i e score que serão usadas para controlar o número da questão atual, o índice da questão atual e a pontuação do jogador, respectivamente
        // cria a variável timer do tipo DispatcherTimer que será usada para controlar o tempo restante para responder a questão atual
        // cria a variavel tempoRestante do tipo inteiro que será usada para armazenar o tempo inicial para responder a questão atual
        // cria a variavel perguntasRespondidas do tipo inteiro que será usada para armazenar a quantidade de perguntas respondidas pelo jogador
        int qNum = 0;
        int i;
        int score;
        DispatcherTimer timer;
        int tempoRestante = 10;
        int perguntasRespondidas = 0;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += Temporizador_Tick;

            // cria o construtor da classe MainWindow que inicializa os componentes da janela e configura o timer para disparar a cada segundo
        }

        private async void checkAnswer(object sender, RoutedEventArgs e)
        {
            // checkAnswer é um método assíncrono que verifica se a resposta selecionada pelo jogador está correta ou não

            timer.Stop(); // para o timer quando o jogador clica em uma das respostas

            Button senderButton = sender as Button; // cria uma variável senderButton do tipo Button que recebe o botão clicado pelo jogador

            // cria uma condicional que verifica se o botão clicado tem a tag "1", que indica que é a resposta correta
            if (senderButton.Tag != null && senderButton.Tag.ToString() == "1")
            {
                score++;
                senderButton.Background = Brushes.LightGreen; // se for a resposta correta, incrementa a pontuação e muda a cor do botão para verde
            }
            else
            {
                senderButton.Background = Brushes.LightSalmon; // se for a resposta incorreta, muda a cor do botão para vermelho
            }

            await Task.Delay(500); // aguarda 2 segundos antes de chamar a função NextQuestion para dar tempo ao jogador de ver se acertou ou errou

            perguntasRespondidas++; // incrementa a quantidade de perguntas respondidas pelo jogador
            qNum++; // incrementa o número da questão atual para passar para a próxima questão


            NextQuestion(); // passa para a próxima questão chamando a função NextQuestion

        }

        private void RestartGame()
        {
            // essa função é chamada quando o jogador clica no botão de jogar novamente

            // redefine os valores das variaveis para reiniciar o jogo
            score = 0; 
            qNum = 0; 
            i = 0;
            perguntasRespondidas = 0;

            StartGame(); //começa o jogo chamando a função StartGame que randomiza a ordem das questões novamente

            // quando o botão de pular questão é clicado, ele desabilita o botão e muda a imagem de fundo para indicar que não pode ser usado novamente
            buttonSkip.IsEnabled = true; 
            buttonSkip.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/buttonSkip.png")));

            NextQuestion();

        }

        private void NextQuestion()
        {
            // essa função é chamada para exibir a próxima questão do quiz

            questionText.Content = "Questão " + (qNum + 1); // atualiza o label questionText para mostrar o número da questão atual (qNum + 1) para o jogador

            //essas variaveis definem o tempo restante para responder a questão atual (começando do 10s) e atualizam o label time para mostrar esse tempo para o jogador
            tempoRestante = 10;
            time.Content = $"{tempoRestante}s";
            timer.Start();

            // verifica se o jogador ainda não respondeu 10 perguntas e se ainda há questões disponíveis na lista questionNumbers. se sim, define a variável i como o número da questão atual (questionNumbers[qNum]). se não, esconde a tela de jogo e exibe a tela de fim de jogo com a pontuação final do jogador
            if (perguntasRespondidas < 10 && qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];
            }
            else // se não, significa que o jogador respondeu 10 perguntas ou não há mais questões disponíveis, então o jogo termina e a tela de fim de jogo é exibida com a pontuação final do jogador
            {
                Jogo.Visibility = Visibility.Collapsed;
                FimDeJogo.Visibility = Visibility.Visible;
                txtPontuacaoFinal.Text = $"{score}/10";

                return;
            }

            foreach (var x in Jogo.Children.OfType<Button>()) // esse foreach percorre todos os botões do painel Jogo e redefine a tag e a cor de fundo de cada botão para o estado inicial, antes de exibir a próxima questão
            {
                if (x.Name == "buttonSkip") // pula o botão de pular questão para não alterar a cor de forma acidental, pois ele não faz parte das alternativas da questão
                    continue;

                x.Tag = "0";
                x.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFAD75F")); 
            }

            // esse switch case é usado para definir a questão atual (pergunta) e as alternativas correspondentes para cada botão (ans1, ans2, ans3, ans4). cada questão é escolhida de forma aleatória a partir da lista questionNumbers que foi embaralhada na função StartGame. cada caso do switch corresponde a uma questão diferente, e define o texto da pergunta e das alternativas, bem como a tag do botão correto (1) para indicar qual é a resposta certa.
            switch (i)
            {
                case 1:

                    txtQuestion.Text = "Na orientação a objetos, o conceito que garante que nenhum acesso direto é concedido aos dados é atribuído por meio do(a):"; 

                    ans1.Content = "Polimorfismo";
                    ans2.Content = "Herança";
                    ans3.Content = "Encapsulamento";
                    ans4.Content = "Abstração";

                    ans3.Tag = "1"; 

                    break; 

                case 2:

                    txtQuestion.Text = "Na orientação a objetos, a sobrecarga é utilizada por meio do conceito de:";

                    ans1.Content = "Encapsulamento";
                    ans2.Content = "Abstração";
                    ans3.Content = "Polimorfismo";
                    ans4.Content = "Herança";

                    ans3.Tag = "1";

                    break;

                case 3:

                    txtQuestion.Text = "Na orientação a objetos, é um recurso que serve para inicializar os atributos e é executado automaticamente sempre que um novo objeto é criado:";

                    ans1.Content = "Método";
                    ans2.Content = "Construtor";
                    ans3.Content = "Destrutor";
                    ans4.Content = "Propriedade";

                    ans2.Tag = "1";


                    break;

                case 4:

                    txtQuestion.Text = "O que é uma interface?";

                    ans1.Content = "Tipo de variável global";
                    ans2.Content = "Contrato que define assinatura dos métodos";
                    ans3.Content = "Tipo de método";
                    ans4.Content = "Espaço na memória para atributos";

                    ans2.Tag = "1";


                    break;

                case 5:

                    txtQuestion.Text = "O que é uma Classe em Orientação a Objetos?";

                    ans1.Content = "Uma variável global";
                    ans2.Content = "Um modelo ou molde para criar objetos";
                    ans3.Content = "Uma função para fazer cálculos";
                    ans4.Content = "Um tipo de dado";

                    ans2.Tag = "1";


                    break;
                case 6:

                    txtQuestion.Text = "Qual conceito permite que uma classe filha herde características de uma classe mãe?";

                    ans1.Content = "Encapsulamento";
                    ans2.Content = "Abstração";
                    ans3.Content = "Polimorfismo";
                    ans4.Content = "Herança";

                    ans4.Tag = "1";


                    break;

                case 7:

                    txtQuestion.Text = "Para que serve o Encapsulamento?";

                    ans1.Content = "Para fazer o código rodar mais rápido";
                    ans2.Content = "Para proteger os dados e controlar o acesso a eles";
                    ans3.Content = "Para facilitar a manutenção do código";
                    ans4.Content = "Para melhorar a legibilidade do código";

                    ans2.Tag = "1";


                    break;

                case 8:

                    txtQuestion.Text = "O que é um Objeto?";

                    ans1.Content = "Tipo de dado de uma variável inteira";
                    ans2.Content = "Instância de uma classe";
                    ans3.Content = "Uma variável global";
                    ans4.Content = "Um tipo de método";

                    ans2.Tag = "1";


                    break;
                case 9:

                    txtQuestion.Text = "Se a classe Cachorro herda da classe Animal, dizemos que:";

                    ans1.Content = "Animal é a subclasse e Cachorro é a superclasse";
                    ans2.Content = "Cachorro é a subclasse e Animal é a superclasse";
                    ans3.Content = "Ambas são classes independentes";
                    ans4.Content = "Ambas são classes irmãs";

                    ans2.Tag = "1";


                    break;

                case 10:

                    txtQuestion.Text = "Qual modificador de acesso restringe a visibilidade de um atributo apenas para a própria classe?";

                    ans1.Content = "private";
                    ans2.Content = "protected";
                    ans3.Content = "public";
                    ans4.Content = "internal";

                    ans1.Tag = "1";

                    break;

                case 11:

                    txtQuestion.Text = "O que são os 'Atributos'?";

                    ans1.Content = "Ações que um objeto pode realizar";
                    ans2.Content = "Características ou dados de um objeto";
                    ans3.Content = "Erros que acontecem em tempo de execução";
                    ans4.Content = "NDA";

                    ans2.Tag = "1"; 
                    break;

                case 12:

                    txtQuestion.Text = "O que são 'Métodos'?";

                    ans1.Content = "Funções definidas dentro de uma classe";
                    ans2.Content = "Os arquivos de configuração do projeto";
                    ans3.Content = "Os tipos de herança possíveis";
                    ans4.Content = "NDA";

                    ans1.Tag = "1";

                    break;

                case 13:

                    txtQuestion.Text = "O que significa um sistema possuir baixo acoplamento?";

                    ans1.Content = "As classes são dependentes entre si";
                    ans2.Content = "O código possui poucas linhas";
                    ans3.Content = "As funções executam de forma síncrona";
                    ans4.Content = "As classes são independentes";

                    ans4.Tag = "1";


                    break;

                case 14:

                    txtQuestion.Text = "O que inicializa o objeto?";

                    ans1.Content = "O atributo estátco";
                    ans2.Content = "A classe principal";
                    ans3.Content = "O método destrutor";
                    ans4.Content = "O método construtor";

                    ans4.Tag = "1";


                    break;

                case 15:

                    txtQuestion.Text = "O que redefine o comportamento de um método da superclasse?";

                    ans1.Content = "Sobrescrita de métodos";
                    ans2.Content = "Injeção de dependências";
                    ans3.Content = "Sobrecarga de métodos";
                    ans4.Content = "Ocultação de atributos";

                    ans1.Tag = "1";


                    break;
                case 16:

                    txtQuestion.Text = "Qual conceito oculta a complexidade lógica?";

                    ans1.Content = "Encapsulamento";
                    ans2.Content = "Abstração";
                    ans3.Content = "Polimorfismo";
                    ans4.Content = "Herança";

                    ans2.Tag = "1";


                    break;

                case 17:

                    txtQuestion.Text = "Qual palavra-chave faz referência ao próprio objeto instanciado?";

                    ans1.Content = "This";
                    ans2.Content = "That";
                    ans3.Content = "It";
                    ans4.Content = "They";

                    ans1.Tag = "1";


                    break;

                case 18:

                    txtQuestion.Text = "Qual palavra-chave faz referência direta a superclasse?";

                    ans1.Content = "Super";
                    ans2.Content = "Void";
                    ans3.Content = "Return";
                    ans4.Content = "This";

                    ans1.Tag = "1";


                    break;
                case 19:

                    txtQuestion.Text = "Qual tipo de método não possui nenhum retorno?";

                    ans1.Content = "Int";
                    ans2.Content = "Void";
                    ans3.Content = "String";
                    ans4.Content = "Boolean";

                    ans2.Tag = "1";


                    break;

                case 20:

                    txtQuestion.Text = "O que siginifica POO?";

                    ans1.Content = "Proteção Orientada a Objetos";
                    ans2.Content = "Proteção Ornamentada a Overload";
                    ans3.Content = "Programação Organizada a Overload";
                    ans4.Content = "Programação Orientada a Objetos";

                    ans4.Tag = "1";

                    break;


            }
        }

        private void StartGame()
        {
            // essa função é chamada para iniciar o jogo e randomizar a ordem das questões do quiz

            // cria uma nova lista de inteiros chamada randomList que recebe os números das questões do quiz (questionNumbers) embaralhados de forma aleatória usando o método OrderBy com um Guid.NewGuid() como chave de ordenação
            var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();

            // salva a lista randomizada na variável questionNumbers
            questionNumbers = randomList;

        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            // essa função é chamada quando o jogador clica no botão de iniciar o jogo

            Menu.Visibility = Visibility.Collapsed; // esconde a tela de menu principal
            Jogo.Visibility = Visibility.Visible; // exibe a tela de jogo

            // inicia o jogo chamando a função StartGame que randomiza a ordem das questões e chama a função NextQuestion para exibir a primeira questão
            StartGame();
            NextQuestion();
        }

        private void buttonRestart_Click(object sender, RoutedEventArgs e)
        {
            // essa função é chamada quando o jogador clica no botão de jogar novamente na tela de fim de jogo

            FimDeJogo.Visibility = Visibility.Collapsed; // esconde a tela de fim de jogo
            Jogo.Visibility = Visibility.Visible; // exibe a tela de jogo novamente
            RestartGame(); // reseta o jogo
        }

        private async void Temporizador_Tick(object? sender, EventArgs e)
        {
            // essa função é chamada a cada segundo pelo timer para atualizar o tempo restante para responder a questão atual

            tempoRestante--;
            time.Content = $"{tempoRestante}s"; // atualiza o label time para mostrar o tempo restante

            // se o tempo restante for igual a zero, para o timer, muda a cor do botão correto para verde para indicar a alternativa correta, aguarda 1 segundo e passa para a próxima questão, sem somar pontos no score
            if (tempoRestante == 0)
            {
                timer.Stop(); 

                foreach (var x in Jogo.Children.OfType<Button>())
                {
                    if (x.Tag != null && x.Tag.ToString() == "1")
                    {
                        x.Background = Brushes.LightGreen;
                    }
                }

                await Task.Delay(1000);

                perguntasRespondidas++;
                qNum++;
                NextQuestion();

            }
        }

        private void buttonSkip_Click(object sender, RoutedEventArgs e)
        {
            // essa função é chamada quando o jogador clica no botão de pular questão

            timer.Stop();

            buttonSkip.IsEnabled = false; // desabilita o botão de pular questão para que o jogador não possa usá-lo novamente durante o jogo
            buttonSkip.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/buttonSkipBlock.png")));
            qNum++;
            NextQuestion(); // passa para a próxima questão chamando a função NextQuestion, sem somar pontos no score
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}