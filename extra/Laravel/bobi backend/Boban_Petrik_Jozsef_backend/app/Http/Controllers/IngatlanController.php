<?php

namespace App\Http\Controllers;

use App\Models\ingatlan;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class IngatlanController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $ingatlanok = ingatlan::with('kategoria')->get();
        return response()->json($ingatlanok);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $validator = Validator::make($request->all(), [
            'kategoria' => 'required',
            'tehermentes' => 'required',
            'ar' => 'required',
            ]);

        if ($validator->fails()) {
            return response()->json(['message'=>'Hiányos adatok.'], 400);
        }
        return ingatlan::create($request->all());

        $ingatlan = ingatlan::create($request->all());
        return response()->json(['id' => $ingatlan->id], 201);
    }
   



    /**
     * Remove the specified resource from storage.
     */
    public function destroy(ingatlan $id)
    {
        $ingatlan = ingatlan::where('id', $id);
        if($ingatlan->exists()){
            $ingatlan->delete();
            return response('', 204);
        }
        return response('az ingatlan nem létezik', 404);

    }
}
