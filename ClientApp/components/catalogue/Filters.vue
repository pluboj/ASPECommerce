<template>
    <div class="filters mb-4">
        <h5 class="mt-4">Filters</h5>
        <b-btn variant="outline-secondary" @click.prevent="reset">
            <i class="fas fa-sync mr-2">Reset</i>
        </b-btn>
        <b-list-group class="mt-4">

            <filter-accordion>
                <span slot="header">Brand</span>
                <b-row slot="body">
                    <b-col cols="6">
                        <div 
                            :class="{ 'filter-item': true, 'active': brands.length === 0 }"
                            @click="clearBrands"
                        >
                            All
                        </div>
                    </b-col>
                    <b-col cols="6" v-for="item in filters.brands" :key="item">
                        <div :class="{ 'filter-item': true, 'active': brands.indexOf(item) > -1 }"
                            @click="filteredBrands(item)">{{ item }}</div>
                    </b-col>
                </b-row>
            </filter-accordion>

        </b-list-group>
    </div>
</template>

<script>
import FilterAccordion from './FilterAccordion.vue';
import vueSlider from 'vue-slider-component';

export default {
    name: 'filters',
    props: {
        filters: {
            type: Object,
            required: true
        }
    },
    components: {
        FilterAccordion,
        vueSlider
    },
    computed: {
        // todo
       
    },
    methods: {
        // todo
    }
}
</script>

<style lang="scss" scoped>
.filter-item {
  margin: 10px 0;
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 10px;
  text-align: center;
  cursor: pointer;

  &.active {
    font-weight: bold;
    color: #17a2b8;
    border-color: #17a2b8;
  }
}

.slider {
  padding: 35px 0 10px 10px;
}
</style>
