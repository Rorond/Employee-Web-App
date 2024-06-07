using Employee.Data.Models;
using Employee.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Model = Employee.Data.Models.Employee;

namespace Employee.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly ICareerRepository _careerRepository;
        private readonly IStudyRepository _studyRepository;
        private readonly ITrainingRepository _trainingRepository;
        public EmployeeController(
            IEmployeeRepository repository, ICareerRepository careerRepository, IStudyRepository studyRepository, ITrainingRepository trainingRepository)
        {
            _repository = repository;
            _careerRepository = careerRepository;
            _studyRepository = studyRepository;
            _trainingRepository = trainingRepository;
        }

        public async Task<IActionResult> Add()
        {
            Model model = new Model();
            model.StudyHistories = new List<StudyHistory>();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Model model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                int id = await _repository.AddAsync(model);

                if (model.StudyHistories != null)
                {
                    foreach (var item in model.StudyHistories)
                    {
                        item.FkEmployeeId = id;
                        await _studyRepository.AddAsync(item);
                    }
                }

                //foreach (var item in model.CareerHistories)
                //{
                //    item.FkEmployeeId = id;
                //    await _careerRepository.AddAsync(item);
                //}

                //foreach (var item in model.Trainings)
                //{
                //    item.FkEmployeeId = id;
                //    await _trainingRepository.AddAsync(item);
                //}

                TempData["msg"] = "Successfully added";
                return RedirectToAction(nameof(List));

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Failed added";
            }

            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _repository.FindAsync(id);
            if (result == null)
                return NotFound();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Model model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                bool result = await _repository.UpdateAsync(model);
                if (result)
                {
                    TempData["msg"] = "Successfully update";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    TempData["msg"] = "Failed update";
                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Failed update";
            }

            return RedirectToAction(nameof(Edit));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> FindById(int id)
        {
            return View();
        }
        public async Task<IActionResult> List(string searchString)
        {
            var result = await _repository.GetAllAsync();
            if (searchString != null)
            {
                result = result.Where(e => e.Email.Contains(searchString));
            }
            return View(result);
        }

        public async Task<IActionResult> Show(int id)
        {
            var result = await _repository.FindAsync(id);
            if (result == null)
                return NotFound();
            return View(result);
        }

    }
}
