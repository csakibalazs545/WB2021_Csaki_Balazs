<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use App\Models\kategoria;

class ingatlan extends Model
{
    public $table = 'ingatlanok';
    public $timestamps = false;

    public function kategoria(){
        return $this->belongsTo(kategoria::class, 'kategoria');
        
    }

    public $guarded = [];
}
