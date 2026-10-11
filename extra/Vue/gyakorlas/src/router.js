import { createRouter, createWebHistory } from "vue-router";
import Openpage from "./pages/Openpage.vue";
import Offers from "./pages/Offers.vue";
import Newad from  "./pages/Newad.vue";


const routes = [
    {
        path: "/",
        name: "Openpage",
        component: Openpage,
    },
    {
        path: "/offers",
        name: "Offers",
        component: Offers,
    },
    {
        path: "/Newad",
        name: "Newad",
        component: Newad,
    },
    
    
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;