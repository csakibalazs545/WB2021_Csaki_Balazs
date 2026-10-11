<template>
    <div class="container">
        <h1 class="text-center">Túra hozzáadása</h1>
        <p>POST kérés küldése a <code>api/Turak</code> végpontra.</p>
    
        <form>
            <div class="mb-3">
                <label for="nev" class="form-label">Név:</label>
                <input type="text" class="form-control" id="nev" v-model="tura.nev">
            </div>

            <div class="mb-3">
                <label for="kategoria" class="form-label">Kategória:</label>
                <select class="form-select" id="kategoria" v-model="tura.kategoriaId">
                    <option value="">Válassz egy kategóriát</option>
                    <option v-for="kategoria in kategoriak" :key="kategoria.id" :value="kategoria.id">
                        {{ kategoria.ikon }}
                        {{ kategoria.nev }}
                    </option>
                </select>
            </div>
            <div class="mb-3">
                <label for="tavolsagKm" class="form-label">Távolság (km):</label>
                <input type="number" class="form-control" id="tavolsagKm" v-model="tura.tavolsagKm">
            </div>
            <div class="mb-3">
                <label for="nehezseg" class="form-label">Nehézség:</label>
                <input type="text" class="form-control" id="nehezseg" v-model="tura.nehezseg">
            </div>
            <div class="mb-3">
                <label for="szintkulonbseg" class="from-label">szintkulonbseg:</label>
                <input type="number" class="form-control" id="szintkulonbseg" v-model="tura.szintkulonbseg">
            </div>
            <div class="mb-3">
                <label for="becsultIdoPerc" class="form-label">Becsült idő (perc):</label>
                <input type="number" class="form-control" id="becsultIdoPerc" v-model="tura.becsultIdoPerc">
            </div>
            <div class="mb-3">
                <label for="helyszin" class="form-label">Helyszín:</label>
                <input type="text" class="form-control" id="helyszin" v-model="tura.helyszin">
            </div>

            <div class="mb-3">
                <label for ="kutyabarat" class="form-label">Kutyabarát:</label>
                <input type="checkbox" class="form-check-input" id="kutyabarat" v-model="tura.kutyabarat">
            </div>
            <button type="submit" class="btn btn-primary" @click.prevent="hozzaadtura">hozzáadás</button>
        </form>
    </div>
        
</template>

<script>
import axios from "axios";
axios.defaults.baseURL = "http://localhost:5000/api";

export default {
    name: "Add",
    data() {
        return {
            tura: {
                nev: "",
                kategoriaId: "",
                tavolsagKm: 0,
                nehezseg: "",
                szintkulonbsegM: 0,
                becsultIdoPerc: 0,
                helyszin: "",
                kutyabarat: false,
            },
            kategoriak: [],
        };
    },
    mounted() {
        axios.get("/kategoriak")
            .then((response) => {
                this.kategoriak = response.data;
            })
            .catch((error) => {
                console.error("Hiba a kategóriák lekérésekor:", error);
            });
    },
    methods: {
        hozzaadtura() {
            axios.post("/turak", this.tura)
                .then(() => {
                   alert("Túra sikeresen hozzáadva!");
                   this.$router.push({ name: 'Home' });
                    // Itt opcionálisan törölheted a form mezőit vagy átirányíthatod a felhasználót egy másik oldalra
                    this.tura = {
                        nev: "",
                        kategoriaId: "",
                        tavolsagKm: 0,
                        nehezseg: "",
                        szintkulonbsegM: 0,
                        becsultIdoPerc: 0,
                        helyszin: "",
                        kutyabarat: false,
                    };
                })
                .catch((error) => {
                    console.error("Hiba a túra hozzáadásakor:", error);
                    alert("Hiba történt a túra hozzáadásakor. Kérlek, próbáld újra.");
                });
        },
    },
};

</script>