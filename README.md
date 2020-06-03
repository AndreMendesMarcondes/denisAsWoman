# adicionar o dotnet 
wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

# instalar o runtime
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install aspnetcore-runtime-3.1

# como usar
clone esse repositório
navegue ate a pasta Comment\Comment\Properties
no arquivo launchSettings.json altere as properties email e pass para seu e-mail e senha do facebook
navegue até a pasta Comment\Comment\
abre o terminal nessa pasta
execute o comando dotnet run Comment.csproj
