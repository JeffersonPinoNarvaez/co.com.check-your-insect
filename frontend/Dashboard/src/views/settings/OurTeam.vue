<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-lg-12">
      
        <h1 class="text-center mb-5 mt-4">Meet Our Team</h1>

        <div class="row justify-content-center mt-4">
          <div v-for="(member, index) in team" :key="index" class="col-lg-4 col-md-6 col-sm-12 mb-4">
            <div class="text-center">
              <img :src="member.image" class="rounded-circle mb-2" :alt="member.name" style="width: 150px; height: 150px;">
              <h3>{{ member.name }}</h3>
              <p>{{ member.role }}</p>
              <CIcon icon="cibGithub" @click="openLink(member.github)" class="c-icon-lg link-icon" @mouseover="isHovering = true" @mouseleave="isHovering = false"/>
            </div>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'TeamPage',
  data() {
    return {
      isHovering: false,
      team: [
        {
          name: 'Santiago Aponte',
          role: 'Backend Dev',
          image: 'assets/images/team/santiago.png',
          github: 'https://github.com/SantiagoAponte'
        },
        {
          name: 'Miguel Angel',
          role: 'ML Designer',
          image: 'assets/images/team/miguel.png',
          github: 'https://github.com/Mikepa22'
        },
        {
          name: 'Jefferson Pino',
          role: 'Frontend Dev',
          image: 'assets/images/team/jefferson.jpg',
          github: 'https://github.com/JeffersonPinoNarvaez'
        }
      ]
    }
  },
  methods: {
    openLink(url) {
       window.open(url, '_blank');
    }
  }
}
</script>

<style scoped>
.link-icon {
  cursor: pointer;
}

.link-icon:hover {
  color: #007bff;
}
</style>