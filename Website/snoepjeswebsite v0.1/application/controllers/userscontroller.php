<?php
 class UsersController extends Controller
 {     
     //Constructor
     public function __construct($model, $controllerName, $action)
     {
         parent::__construct($model, $controllerName, $action);
     }
     
     
     public function homepage()
     {
         $message = '';
         $this->set('header', "Oil's Well van Marijn!");
         $this->set('message', $message);
         
     }
     public function downloadpage()
     {
            $downloads = '<h3><a href="public/files/game.zip" download>Download de Game</a></h3><br />
                                 <h3><a href="public/files/handleiding_nl.pdf" download>Download de handleiding (NL)</a></h3><br />
                                 <h3><a href="public/files/handleiding_en.pdf" download>Download de handleiding (EN)</a></h3>';  
         if( isset($_SESSION['email'])){
             $message = $downloads;
         }else{
             $message = '<div class="loginform">
                        <form method="post" action="'.BASE_URL.'users/downloadpage">
                                <label for="email">E-mail adres: </label><input type="email" name="email"/></br>
                                <label for="password">Wachtwoord: </label><input type="password" name="password"/></br>
                                <label></label>
                                <input type="submit" name="submit" value="Log in"/>&nbsp;&nbsp;&nbsp;
                                <a href="'.BASE_URL.'/users/registreren"> Registreer </a>
                            </form>
                        </div>';
             if (isset($_POST['submit']))
             {     
             $result = $this->model->check_user($_POST);
                 if( $result[0]->emailentries == 0){
                     $message .= "<p>E-mail en wachtwoordcombinatie niet herkent, probeer opnieuw als u al een account heeft, of registreer eerst een account </p>
                     <a href'".BASE_URL."/users/registreren'>";
                 }
                 else{
                     $message = '<p>Welkom terug</p><br>'. $downloads;
                    $_SESSION['email'] = $_POST['email'];
                 }
             }
         }
         $this->set('header', "Download hier Oil's Well");
         $this->set('message', $message);
         
     }
     public function registreren()
     {
         $message = '<p>Vul hieronder uw gegevens in om toegang te krijgen tot onze game: Oil\'s well!</p>
                    <br />
                    <form method="post" action="'.BASE_URL.'users/registreren ">
                        <label for="email"> E-mailadres: </label>
                        <input type="email" id="email" name="email" /><br/>
                        <label for="voornaam"> Voornaam: </label>
                        <input type="text" id="voornaam" name="voornaam" /><br/>
                        <label for="tussenvoegsel"> Tussenvoegsel: </label>
                        <input type="text" id="tussenvoegsel" name="tussenvoegsel" /><br/>
                        <label for="achternaam"> Achternaam: </label>
                        <input type="text" id="achternaam" name="achternaam" /><br/>
                        <label for="password"> Wachtwoord: </label>
                        <input type="password" id="password" name="password" /><br/>
                        <label for="password-repeat"> Wachtwoord bevestiging: </label>
                        <input type="password" id="password-repeat" name="password-repeat" /><br/>
                        <label></label>
                        <input type=submit name=submit value=Registreer />
                    </form>';
         $header = "Registreer hier";
         if (isset($_POST['submit']))
         {     
         $result = $this->model->check_user($_POST);
             if( $result[0]->emailentries == 0){
                 $this->model->insert_into_users($_POST);
                 $header = "Welkom bij Marijn!";
                 $message = "<div class='loginform'>
                            <form>
                            <label for='email'>E-mail adres: </label><input type='email' name='email'/></br>
                            <label for='password'>Wachtwoord: </label><input type='password' name='password'/></br>
                            <label></label><input type='submit' name='submit' value='Log in'/>
                            </form></div>";
             }
             else{
                 $message = "Dit e-mail adres is al in gebruik, u kunt inloggen met het eerder gemaakte account";
             }
         }
         $this->set('header', $header);
         $this->set('message', $message);
         
     }
 }
?>