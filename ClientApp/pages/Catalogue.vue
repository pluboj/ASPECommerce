<template>
    <b-container fluid class="page">
        <b-row>
        <b-col cols="3">
            <filters :filters="filters" />
        </b-col>
        <b-col cols="9">
            <product-list :products="products" />
        </b-col>
        </b-row>
    </b-container>
</template>

<script>
import ProductList from '../components/catalogue/ProductList.vue';
import Filters from "../components/catalogue/Filters.vue";

export default {
    name: 'catalogue',
    components: {
        ProductList,
        Filters
    },
    data () {
        return {
            products: [],
            filters: {
                brands: [],
                capacity: [],
                colours: [],
                os: [],
                features: []
            }
        }
    },
    mounted() {
    fetch("/api/products")
        .then(response => {
            return response.json();
        })
        .then(products => {
            this.products = products;
        })
    }
}
</script>
