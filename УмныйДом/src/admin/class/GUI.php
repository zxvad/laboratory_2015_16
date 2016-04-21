<?php

/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 21.04.2016
 * Time: 0:34
 */
abstract class GUI
{
    public $type;
    public function init() {
        require_once("interface/".$this->type.".html");
    }
}