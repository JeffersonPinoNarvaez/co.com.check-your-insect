<template>
  <div class="container-fluid">
    <!-- Improved Header and Text -->
    <div class="row mb-4">
      <div class="col-lg-12">
        <h1 class="text-center">Discover Our Categories</h1>
        <p>Explore the fascinating world of insects with our ever-evolving machine learning-based clasification service. We're constantly updating our classes and improving our ML algorithms to provide you with the most accurate and comprehensive insect identification experience. Below are the types currently supported:</p>
      </div>
    </div>
    <!-- Insect Categories Grid -->
    <div class="row">
      <div v-for="(category, index) in categories" :key="index" class="col-lg-4 col-md-6 col-sm-12 mb-4">
        <div class="card">
          <img :src="category.coverPicture" class="card-img-top" :alt="category.name">
          <div class="card-body text-center">
            <h5 class="card-title">{{ category.name }}</h5>
            <button class="btn btn-primary" @click="showExtendInfo(category)">Facts</button>
          </div>
        </div>
      </div>
    </div>
    <CModal :visible="showMoreInfo" @close="() => { showMoreInfo = false }">
      <CModalHeader>
        <CModalTitle>Did you know that {{ selectedCategory.name }} ...</CModalTitle>
      </CModalHeader>
      <CModalBody>
        <ul>
          <li v-for="(fact, index) in selectedCategory.facts" :key="index"> {{ fact }}</li>
        </ul>
      </CModalBody>
      <CModalFooter>
        <CButton color="secondary" @click="() => { showMoreInfo = false }">
          Close
        </CButton>
      </CModalFooter>
    </CModal>
  </div>
</template>
<script>
import { configurations } from '../../config';

export default {
  data() {
    return {
      showMoreInfo: false,
      selectedCategory: {},
      categories: configurations.app.categories
    }
  },
  methods: {
    showExtendInfo(category) {
      this.selectedCategory = category;
      this.showMoreInfo = true;
    }
  }
}
</script>