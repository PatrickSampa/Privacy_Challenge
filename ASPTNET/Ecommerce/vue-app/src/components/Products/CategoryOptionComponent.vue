<template>
  <div class="select-container">
    <label for="category-select">Selecione uma categoria:</label>
    <select v-model="selectedOption" class="select-box" @change="onSelectChange">
      <option v-for="category in categories" :key="category.name" :value="category.name">
        {{ category.name }}
      </option>
    </select>
  </div>
</template>

<script>
export default {
  name: 'CategoryOptionComponent',
  data() {
    return {
      selectedOption: 'Todos',
      categories: [
        { name: 'Todos' },
        { name: 'Games' },
        { name: 'Jogos' }
      ]
    };
  },
  methods: {
    onSelectChange() {
      this.$emit('categoryChanged', this.selectedOption);
    }
  }
}
</script>
<style scoped>
.select-container {
  max-width: 300px;
  margin: 20px auto;
  font-family: 'Arial', sans-serif;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.select-box {
  width: 100%;
  padding: 8px 10px;
  border: 2px solid #007BFF;
  border-radius: 5px;
  background-color: white;
  color: #333;
  font-size: 16px;
  cursor: pointer;
  outline: none;
}

.select-box:hover {
  border-color: #0056b3;
}

.select-box:focus {
  box-shadow: 0 0 8px rgba(0, 123, 255, 0.8);
}

.selected-option {
  margin-top: 10px;
  font-size: 14px;
  color: #555;
}
</style>