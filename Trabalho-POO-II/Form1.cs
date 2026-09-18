using System.Numerics;
using System.IO;

namespace Fighter_Jet_Shooting_Game_MOO_ICT
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, isGameOver;
        int score;
        int playerSpeed = 12;
        List<Enemy> enemies = new List<Enemy>(); // Lista para armazenar os inimigos do jogo.
        int lifes = 3; //Criação de uma variável global para armazenar o número de vidas do jogador.

        List<PictureBox> balas = new List<PictureBox>(); //Lista para armazenar as balas disparadas pelo jogador.

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            txtVidas.Enabled = false; // Bloqueia o clique do mouse e impede de editar as vidas //
            txtScore.Enabled = false; // Bloqueia o clique do mouse e impede de editar o score //
            resetGame();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            // Atualiza o placar e mostra o High Score (Record) do sistema//

            txtScore.Text = "Score: " + score + " | Recorde: " + CarregarHighScore();

            // LÓGICA DOS INIMIGOS //
            foreach (Enemy enemy in enemies)
            {
                enemy.Move();

                // Se o inimigo passar do fundo da tela
                if (enemy.Sprite.Top > 710)
                {
                    lifes -= 1;
                    txtVidas.Text = "Vidas: " + lifes.ToString();
                    enemy.ResetPosition();

                    if (lifes <= 0)
                    {
                        gameOver();
                    }
                }
            }

            // 2. LÓGICA DA BOMBA //
            if (bomb.Top > 710)
            {
                bomb.Top = rnd.Next(0, 1000) * -1;
                bomb.Left = rnd.Next(20, 600);
            }

            // 3. LÓGICA DE MOVIMENTO DO JOGADOR //
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true && player.Left < 688)
            {
                player.Left += playerSpeed;
            }

            // 4. LÓGICA DOS TIROS //
            for (int i = balas.Count - 1; i >= 0; i--)
            {
                PictureBox balaAtual = balas[i];
                balaAtual.Top -= 20; // Velocidade da bala //

                // Se o tiro sair da tela, ele é removido //
                if (balaAtual.Top < -30)
                {
                    balas.RemoveAt(i);
                    this.Controls.Remove(balaAtual);
                    continue;
                }

                // Colisão do tiro com os Inimigos //
                foreach (Enemy enemy in enemies)
                {
                    if (balaAtual.Bounds.IntersectsWith(enemy.Sprite.Bounds))
                    {
                        score += 1;
                        enemy.ResetPosition();
                        balas.RemoveAt(i);
                        this.Controls.Remove(balaAtual);
                        break; // Sai do loop de inimigos, pois a bala já foi destruída //
                    }
                }

                // Colisão do tiro com a Bomba (só verifica se a bala não foi destruída no passo anterior) //
                if (this.Controls.Contains(balaAtual) && balaAtual.Bounds.IntersectsWith(bomb.Bounds))
                {
                    score -= 1;
                    bomb.Top = -1000;
                    bomb.Left = rnd.Next(20, 600);
                    balas.RemoveAt(i);
                    this.Controls.Remove(balaAtual);
                    continue;
                }
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Space && !isGameOver)
            {
                //Aperta Espaço e ele instancia uma nova bala.
                PictureBox novaBala = new PictureBox();

                //Aplica a imagem da bala no PictureBox.
                novaBala.Image = Properties.Resources.bullet;
                novaBala.SizeMode = PictureBoxSizeMode.StretchImage;
                novaBala.Size = new Size(10, 30);

                novaBala.Top = player.Top - 20; //Posiciona a bala na frente do avião do jogador.

                //Subtrai 5 para que a bala fique centralizada em relação ao avião do jogador.
                novaBala.Left = player.Left + (player.Width / 2) - 5;


                this.Controls.Add(novaBala); //Adiciona a bala na tela.
                novaBala.BringToFront(); // Traz a bala para frente dos outros elementos da tela
                balas.Add(novaBala); //Adiciona a bala na lista de balas disparadas.


            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            gameTimer.Start();
            enemies.Clear();
            enemies.Add(new NormalEnemy(enemyOne, 6));
            enemies.Add(new NormalEnemy(enemyTwo, 6));
            enemies.Add(new FastEnemy(enemyThree, 6)); // O inimigo 3 será mais rápido!
            lifes = 3; //Assim que o jogo dá reset as vidas voltam a ser 3.
            txtVidas.Text = "Vidas: " + lifes.ToString(); //Atualiza o texto do txtVidas para mostrar o número de vidas.
            txtScore.Text = "Score: " + score + " | Recorde: " + CarregarHighScore();


            enemyOne.Left = rnd.Next(20, 600);
            enemyTwo.Left = rnd.Next(20, 600);
            enemyThree.Left = rnd.Next(20, 600);
            bomb.Left = rnd.Next(20, 600); // Gera uma posição aleatória para a bomba no eixo X, para que ela não apareça sempre na mesma posição.

            enemyOne.Top = rnd.Next(0, 200) * -1;
            enemyTwo.Top = rnd.Next(0, 500) * -1;
            enemyThree.Top = rnd.Next(0, 900) * -1;
            bomb.Top = rnd.Next(0, 1000) * -1; // Gera uma posição aleatória para a bomba no eixo Y, multiplicado por -1 para que ela apareça fora da tela e dê impressão que está surgindo do topo da tela.

            score = 0;

            //Limpa todos os tiros da tela do jogo anterior
            foreach (PictureBox bala in balas)
            {
                this.Controls.Remove(bala);
            }
            balas.Clear();
        }

        private string highScoreFile = "highscore.txt";

        // Método para carregar o recorde do arquivo de texto
        private int CarregarHighScore()
        {
            try
            {
                // Se o arquivo existir, lê o número de dentro dele
                if (File.Exists(highScoreFile))
                {
                    string texto = File.ReadAllText(highScoreFile);
                    if (int.TryParse(texto, out int recordeSalvo))
                    {
                        return recordeSalvo;
                    }
                }
            }
            catch (Exception)
            {
                // Caso ocorra algum erro de leitura, retorna 0 por segurança
            }
            return 0; // Se não existir arquivo, o recorde inicial é 0
        }

        // Método para salvar o novo recorde no arquivo de texto
        private void SalvarHighScore(int novoScore)
        {
            try
            {
                int recordeAtual = CarregarHighScore();
                if (novoScore > recordeAtual)
                {
                    // Escreve o novo recorde no arquivo highscore.txt
                    File.WriteAllText(highScoreFile, novoScore.ToString());
                }
            }
            catch (Exception)
            {
                // Tratamento de exceção caso o Windows bloqueie a escrita
            }
        }

        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();

            // Salva a pontuação atual no arquivo de texto se for maior que a anterior
            SalvarHighScore(score);

            // Exibe o game over junto com o recorde carregado do .txt
            txtScore.Text += Environment.NewLine + "Game Over!!" +
                             Environment.NewLine + "Recorde: " + CarregarHighScore() +
                             Environment.NewLine + "Press Enter to try again.";
        }

        private void txtVidas_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
