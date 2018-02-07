<?php
/**
 * 同城飞机大战模块微站定义
 *
 * @author xiongyingjie
 * @url 
 */
defined('IN_IA') or exit('Access Denied');

class Panda_airplanModuleSite extends WeModuleSite {
public function doMobileInit() {
        global $_W, $_GPC;
        load()->func('tpl');
        include $this->template('Init');
    }

}