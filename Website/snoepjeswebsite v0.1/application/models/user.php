<?php
    class User extends Model
    {
        public function insert_into_users($post)
        {   
            $query = "INSERT INTO `gebruikers` (`id`,
                                           `email`,
                                           `voornaam`,
                                           `tussenvoegsel`,
                                           `achternaam`,
                                           `password`)
                      VALUES              (Null,
                                           '".$post['email']."',
                                           '".$post['voornaam']."',
                                           '".$post['tussenvoegsel']."',
                                           '".$post['achternaam']."',
                                           '".$post['password']."')";
            $this->query($query);
            
        }
        
        public function check_user($post){
            
            $query = "SELECT COUNT(*) AS emailentries
                      FROM `gebruikers` WHERE `email` = '".$post['email']."' AND `password` = '".$post['password']."'";
            return $this->query($query);
        }
        
        public function select_all()
        {
            $query = "SELECT *
                      FROM `gebruikers`";
            return $this->query($query);
        }   
		public function edit_in_users($post)
		{
			$query = "UPDATE `users` 
			
						SET 				email = '".$post['email']."',
						WHERE				id= ".$post['id']." ";
            $this->query($query);
		}
		public function delete_user($post)
		{
			
			$query = "	DELETE FROM `users` 
						
						WHERE id= ".$post['id']."";	
            $this->query($query);
		}
    }
?>