<template>
  <div class="container-fluid">
    <div class="row mb-4">
      <div class="col-lg-12">
        <h2 class="text-center">Protecting Insects and Biodiversity</h2>
        <p class="text-center">Explore resources, guides, videos, and images to learn how you can contribute to protecting insects and preserving biodiversity around the world.</p>
      </div>
    </div>

    <div class="row">
      <div class="col-lg-4 mb-4">
        <div class="card h-100">
          <div class="card-body d-flex justify-content-between">
            <div>
              <h5 class="card-title">Guides</h5>
              <p class="card-text">Discover informative guides on insect conservation, biodiversity preservation, and sustainable practices.</p>
            </div>
            <button @click="redirectTo('https://biodiversitygroup.org/insects/')" class="btn btn-link text-blue">Explore</button>
          </div>
        </div>
      </div>

      <div class="col-lg-4 mb-4">
        <div class="card h-100">
          <div class="card-body d-flex justify-content-between">
            <div>
              <h5 class="card-title">Information</h5>
              <p class="card-text">Learn about the importance of insects in ecosystems, threats they face, and actions you can take to help.</p>
            </div>
            <button @click="redirectTo('https://www.worldwildlife.org/magazine/issues/spring-2023/articles/here-s-how-insects-help-keep-ecosystems-in-balance')" class="btn btn-link text-blue">Explore</button>
          </div>
        </div>
      </div>

      <div class="col-lg-4 mb-4">
        <div class="card h-100">
          <div class="card-body d-flex justify-content-between">
            <div>
              <h5 class="card-title">Videos</h5>
              <p class="card-text">Watch engaging videos showcasing the beauty of insects, conservation efforts, and success stories.</p>
            </div>
            <button @click="redirectTo('https://www.youtube.com/watch?v=yJX1Te0jey0')" class="btn btn-link text-blue">Explore</button>
          </div>
        </div>
      </div>

      <div class="col-lg-4 mb-4">
        <div class="card h-100">
          <div class="card-body d-flex justify-content-between">
            <div>
              <h5 class="card-title">Images</h5>
              <p class="card-text">Browse stunning images of insects and their habitats, captured by photographers and enthusiasts.</p>
            </div>
            <button @click="redirectTo('https://speccollstories.ncl.ac.uk/The-Beauty-of-Insects/')" class="btn btn-link text-blue">Explore</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    redirectTo(url) {
      window.open(url, '_blank');
    }
  }
}
</script>

<style>
.text-blue {
  color: #007bff !important;
}
</style>