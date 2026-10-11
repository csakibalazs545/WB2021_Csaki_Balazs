<template>

<div class="container">
        <h1 class="text-center">Ajánlataink</h1>

        <table>
            <tr>

                <th>Kategória</th>
                <th>Leírás</th>
                <th>Hirdetés dátuma</th>
                <th>Tehermentes</th>
                <th>fenykep</th>

            </tr>
            <tr v-for="ingatlan in ingatlanok" :key="ingatlan.id">
                <td>{{ ingatlan.kategoriaNev }}</td>
                <td>{{ ingatlan.leiras }}</td>
                <td>{{ ingatlan.hirdetesDatuma }}</td>
                <td class="text-center" :class="ingatlan.tehermentes ? 'zold': 'piros'">
                    {{ ingatlan.tehermentes ? 'Igen' : 'Nem' }}</td>
                <td>
                    <img :src="ingatlan.kepUrl" alt="">

                </td>
                

            </tr>
            
        </table>
    </div>   

</template>

<script>
import axios from "axios";
axios.defaults.baseURL = "http://localhost:5000/api";


export default {
    name: "Offers",
    data() {
        return {
            ingatlanok: [],
        };
    },
    mounted() {
        axios.get("/ingatlan")
            .then((response) => {
                this.ingatlanok = response.data;
            })
            .catch((error) => {
                console.error("Hiba az ingatlanok lekérésekor:", error);
            });
    },
    
};
</script>

<style scoped>
table {
    width: 100%;
    border-collapse: collapse;
    margin: 20px auto;
    box-shadow: 5px 5px 15px rgba(0, 0, 0, 0.1);

}

table th, table td {
    border-bottom: 1px solid #ddd;
    padding: 12px;
    text-align: left;
}

tr th, tr td{
    text-align: center;
}



.zold {
    color: green;
}

.piros {
    color: red;
}

img {
    max-width: 100px;
    width: 100px;
}

</style>