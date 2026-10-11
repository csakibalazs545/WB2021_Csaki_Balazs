<?php

namespace App\Http\Controllers;

use App\Models\Ingatlan;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class IngatlanController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return Ingatlan::with('kategoria')->get();
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
         {
        $validator = Validator::make($request->all(), [
            'kategoria' => 'required',
            'ar' => 'required',
        ]);
        if ($validator->fails()) {
            return response()->json(['message' => 'Hiányos adatok'], 400);
        }
        $ingatlan = Ingatlan::create($request->all());
        return response()->json(['id' => $ingatlan->id], 201);
    }
    }

    /**
     * Display the specified resource.
     */
    public function show(Ingatlan $ingatlan)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, $id)
{
    // 1. VALIDÁCIÓ: A kért kötelező (required) mezők ellenőrzése
    $validator = Validator::make($request->all(), [
        'kategoria' => 'required', // A kategóriát muszáj elküldeni
        'ar' => 'required',        // Az árat muszáj elküldeni
    ]);

    // 2. HA HIÁNYZIK VALAMELYIK KÖTELEZŐ:
    if ($validator->fails()) {
        return response()->json("Hiányos adatok.", 400);
    }

    // 3. INGATLAN KERESÉSE AZ ADATBÁZISBAN
    $ingatlan = Ingatlan::find($id);

    // 4. HA NINCS ILYEN ID:
    if (!$ingatlan) {
        return response()->json("Az ingatlan nem létezik.", 404);
    }

    // 5. FRISSÍTÉS
    // (A $request->all() az összes elküldött mezőt frissíti, nem csak a kategóriát és az árat)
    $ingatlan->update($request->all());

    // 6. VÁLASZ (Sikeres frissítés)
    return response('', 204); 
}


    /**
     * Remove the specified resource from storage.
     */
    public function destroy($id)
    {
        // Megkeressük a terméket az URL-ben kapott ID alapján
        $ingatlan = Ingatlan::where('id', '=', $id);
        // Ha létezik a termék...
        if ($ingatlan->exists()) 
        {
            $ingatlan->delete(); // ...akkor letöröljük
            return response('', 204); // és visszaadjuk a 204-es kódot (No Content)
        }
        // Ha az if nem futott le, mert nincs ilyen ID, akkor 404-es hibát dobunk a kért szöveggel
        return response('Az ingatlan nem létezik.', 404);
    } 


}

