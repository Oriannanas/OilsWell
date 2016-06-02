<?php
 class SqlQuery
 {
     private $db_connect;     
     
     public function connect($host, $user, $password, $dbname)
     {
         $this->db_connect = mysqli_connect($host, $user, $password, $dbname);         
     }    
     
     public function query($query)
     {
         $result = mysqli_query($this->db_connect, $query) or die(mysqli_error($this->db_connect));
         if (gettype($result) == 'object')
         {
             $object_array = array();
             while ($item = mysqli_fetch_object($result))
             {
                $object_array[] = $item;
             }
             return $object_array;
         }
        
     }
 }
?>