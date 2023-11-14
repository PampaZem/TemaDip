document.addEventListener("DOMContentLoaded", function () {
    // Функция для генерации капчи
    function generateCaptcha() {
      const num1 = Math.floor(Math.random() * 10);
      const num2 = Math.floor(Math.random() * 10);
      const operator = ['+', '-', '*'][Math.floor(Math.random() * 3)];
  
      const question = `${num1} ${operator} ${num2}`;
      const answer = eval(question);
  
      document.getElementById('captcha-question').textContent = question;
      return answer;
    }
  
    // Добавляем капчу к форме
    let captchaAnswer = generateCaptcha();
    const captchaAnswerInput = document.getElementById('captcha-answer');
    const captchaSubmitButton = document.getElementById('captcha-submit');
  
    captchaSubmitButton.addEventListener('click', function () {
      const userAnswer = parseInt(captchaAnswerInput.value, 10);
  
      if (userAnswer === captchaAnswer) {
        // Если пользователь правильно решил капчу, перенаправляем на основной сайт
        window.location.href = 'https://pampazem.github.io/TemaDip/Newton.cs';
      } else {
        alert('Неверный ответ. Попробуйте ещё раз.');
        // Генерируем новую капчу
        captchaAnswer = generateCaptcha();
        captchaAnswerInput.value = '';
      }
    });
  });
