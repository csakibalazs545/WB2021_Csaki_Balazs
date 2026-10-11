<?php

namespace App\Http\Controllers;

use App\Models\Game;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class GameController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return Game::all();
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        {
        $validator = Validator::make($request->all(), [
            'name' => 'required',
            'genre' => 'required',
            'price' => 'required',
            'Owners' => 'required',
            'PositiveReviews' => 'required',
            'ReleaseYear' => 'required',

        ]);
        if ($validator->fails()) {
            return response()->json(['message' => 'Hiányos adatok'], 400);
        }
        $game = Game::create($request->all());
        return response()->json(['id' => $game->id], 201);
    }

    }

    /**
     * Display the specified resource.
     */
    public function show($id)
    {
        $game = Game::find($id);

        if (!$game)
        {
            return response()->json([
                'message' => 'Game not found'
            ], 404);
        }
        return response()->json($game, 200);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, $id)
{
    // 1. VALIDÁCIÓ: A kért kötelező (required) mezők ellenőrzése
    $validator = Validator::make($request->all(), [
        'name' => 'required',
        'genre' => 'required',
        'price' => 'required',       
    ]);

    // 2. HA HIÁNYZIK VALAMELYIK KÖTELEZŐ:
    if ($validator->fails()) {
        return response()->json("Hiányos adatok.", 400);
    }

    // 3. INGATLAN KERESÉSE AZ ADATBÁZISBAN
    $game = Game::find($id);

    // 4. HA NINCS ILYEN ID:
    if (!$game) {
        return response()->json("A játék nem létezik.", 404);
    }

    // 5. FRISSÍTÉS
    // (A $request->all() az összes elküldött mezőt frissíti, nem csak a kategóriát és az árat)
    $game->update($request->all());

    // 6. VÁLASZ (Sikeres frissítés)
    return response('', 204); 
}


    /**
     * Remove the specified resource from storage.
     */
    public function destroy($id)
    {
        // Megkeressük a terméket az URL-ben kapott ID alapján
        $game = Game::where('id', '=', $id);
        // Ha létezik a termék...
        if ($game->exists()) 
        {
            $game->delete(); // ...akkor letöröljük
            return response('', 204); // és visszaadjuk a 204-es kódot (No Content)
        }
        // Ha az if nem futott le, mert nincs ilyen ID, akkor 404-es hibát dobunk a kért szöveggel
        return response('A játék nem létezik.', 404);
    }
}
