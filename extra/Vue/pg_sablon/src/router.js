import { createRouter, createWebHistory } from "vue-router";
import Home from "./pages/Home.vue";
import list from "./pages/list.vue";
import category from "./pages/category.vue";
import Update from "./pages/Update.vue";
import Add from "./pages/Add.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/list",
        name: "list",
        component: list,
    },
    {
        path: "/category",
        name: "category",
        component: category,
    },
    {
        path: "/update/:id",
        name: "Update",
        component: Update,
    },
    {
        path: "/add",
        name: "Add",
        component: Add,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;