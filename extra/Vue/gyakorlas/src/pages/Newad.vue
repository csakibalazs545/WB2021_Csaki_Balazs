<template>
<div class="container">
        <h2 class="mb-4 text-center">Új hirdetés elküldése</h2>
        <div class="row">
            <div class="offset-lg-3 offset-md-2 col-lg-6 col-md-8 col-12">
                <div class="mb-3">
                    <label for="category" class="form-label">Ingatlan kategóriája</label>
                    <select class="form-select" v-model="ujingatlanurlap.kategoriaid">
            <option value="">Kérem Válasszon</option>
            <option v-for="kategoria in kategoriak" :key="kategoria.id" :value="kategoria.id">
                {{ kategoria.megnevezes }}
            </option>
                    </select>
                </div>

                <div class="mb-3">
                    <label for="date" class="form-label">Hirdetés dátuma</label>
                    <input type="date" class="form-control" name="hirdetesDatuma" readonly v-model="ujingatlanurlap.hirdetesDatuma">
                </div>
                <div class="mb-3">
                    <label for="description" class="form-label">Ingatlan leírása</label>
                    <textarea class="form-control" name="leiras" rows="3" v-model="ujingatlanurlap.leiras"></textarea>
                </div>
                <div class="form-check mb-3">
                    <input class="form-check-input" type="checkbox" name="tehermentes" v-model="ujingatlanurlap.tehermentes">
                    <label class="form-check-label" for="creditFree">Tehermentes ingatlan</label>
                </div>
                <div class="mb-3">
                    <label for="pictureUrl" class="form-label">Fénykép az ingatlanról</label>
                    <input type="url" class="form-control" name="kepUrl" v-model="ujingatlanurlap.kepurl">
                </div>
                <div class="mb-3 text-center">
                    <button class="btn btn-primary px-5" @click="addingatlan">Küldés</button>
                </div>

                <div class="alert alert-danger alert-dismissible" role="alert" v-show="hiba">
                    <strong>{{hiba}}</strong>
                    <button type="button" class="btn-close" @click="hiba = ''"></button>
                </div>

            </div>
        </div>
    </div>
</template>

<script>
 import axios from "axios";
        axios.defaults.baseURL = "http://localhost:5000/api";

        export default {
            name: "Newad",
            data() {
                return {
                    kategoriak: [],
                    ujingatlanurlap:{
                        kategoriaid: '',
                        hirdetesDatuma: new Date().toISOString().substr(0, 10),
                        leiras: '',
                        tehermentes: true,
                        kepurl: ''
                    },
                    hiba: '',
                    
                };
            },
            mounted() {
                axios.get("/kategoriak")
                    .then((response) => {
                        this.kategoriak = response.data;
                    })
                    .catch((error) => {
                        console.error("Hiba a kategóriák lekérésekor:", error);
                        this.hiba = "Hiba a kategóriák lekérésekor";
                    });
            },


            methods: {
        addingatlan() {
            axios.post("/ujingatlan", this.ujingatlanurlap)
                .then(() => {
                   alert("ingatlan sikeresen hozzáadva!");
                   this.$router.push({ name: 'Offers' });

                   
                })
                .catch((error) => {
                    console.error("Hiba az ingatlan hozzáadásakor:", error);
                    this.hiba = "Hiba történt az ingatlan hozzáadásakor. Kérlek, próbáld újra.";
                });
        },
    },
            
        };


        
</script>

