<?php
 class Model extends SqlQuery
 {
     protected $model;
     
     public function __construct()
     {
         $this->connect(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);
         $this->model = get_class($this);
     }       
 }
?>